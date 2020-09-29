using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreDemo_3_0.Models;
using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Model;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo_3_0.Controllers
{
    public class DocusignController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        MyCredential credential = new MyCredential();
        private string INTEGRATOR_KEY = "d1fbafa4-04fe-4322-93b1-e4bb2b9ffc2d";


        public DocusignController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult SendDocumentforSign()
        {
            return View();
        }
        public ActionResult CustomSign()
        {
            return View();
        }
             

        [HttpPost]
        public ActionResult SendDocumentforSign(Recipient recipient)
        {
            Recipient recipientModel = new Recipient();
           
            var fileName = "";
            var fullPath = "";

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                var webRootPath = _hostingEnvironment.WebRootPath;
                var newPath = Path.Combine(webRootPath, "documents");
                if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);

                if (file.Length > 0)
                {
                    // MemoryStream memoryStream = inputStream as MemoryStream;
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                     fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {

                        file.CopyTo(stream);
                         
                    }
                }
            }

            byte[] data;
            data = System.IO.File.ReadAllBytes(fullPath);
            var serverpath = fileName + recipient.Name.Trim() + ".pdf";
            System.IO.File.WriteAllBytes(serverpath, data);
            docusign(serverpath, recipient.Name, recipient.Email);
            return View();
        }

        public string loginApi(string usr, string pwd)
        {
            // we set the api client in global config when we configured the client 
            ApiClient apiClient = Configuration.Default.ApiClient;
            string authHeader = "{\"Username\":\"" + usr + "\", \"Password\":\"" + pwd + "\", \"IntegratorKey\":\"" + INTEGRATOR_KEY + "\"}";
            Configuration.Default.AddDefaultHeader("X-DocuSign-Authentication", authHeader);

            // we will retrieve this from the login() results
            string accountId = null;

            // the authentication api uses the apiClient (and X-DocuSign-Authentication header) that are set in Configuration object
            AuthenticationApi authApi = new AuthenticationApi();
            LoginInformation loginInfo = authApi.Login();

            // find the default account for this user
            foreach (DocuSign.eSign.Model.LoginAccount loginAcct in loginInfo.LoginAccounts)
            {
                if (loginAcct.IsDefault == "true")
                {
                    accountId = loginAcct.AccountId;
                    break;
                }
            }
            if (accountId == null)
            { // if no default found set to first account
                accountId = loginInfo.LoginAccounts[0].AccountId;
            }
            return accountId;
        }

        public void docusign(string path, string recipientName, string recipientEmail)
        {

            ApiClient apiClient = new ApiClient("https://demo.docusign.net/restapi");
            Configuration.Default.ApiClient = apiClient;

            //Verify Account Details
            string accountId = loginApi(credential.UserName, credential.Password);

            // Read a file from disk to use as a document.
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);

            EnvelopeDefinition envDef = new EnvelopeDefinition();
            envDef.EmailSubject = "Jitendra sign on pdf file";

            // Add a document to the envelope
            Document doc = new Document();
            doc.DocumentBase64 = System.Convert.ToBase64String(fileBytes);
            doc.Name = Path.GetFileName(path);
            doc.DocumentId = "1";

            envDef.Documents = new List<Document>();
            envDef.Documents.Add(doc);

            // Add a recipient to sign the documeent
            DocuSign.eSign.Model.Signer signer = new DocuSign.eSign.Model.Signer();
            signer.Email = recipientEmail;
            signer.Name = recipientName;
            signer.RecipientId = "1";

            envDef.Recipients = new DocuSign.eSign.Model.Recipients();
            envDef.Recipients.Signers = new List<DocuSign.eSign.Model.Signer>();
            envDef.Recipients.Signers.Add(signer);

            //set envelope status to "sent" to immediately send the signature request
            envDef.Status = "sent";

            // |EnvelopesApi| contains methods related to creating and sending Envelopes (aka signature requests)
            EnvelopesApi envelopesApi = new EnvelopesApi();
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(accountId, envDef);

            // print the JSON response
            var result = JsonConvert.SerializeObject(envelopeSummary);
        }
    }



    public class MyCredential
    {
        public string UserName { get; set; } = "smkgnanavel@gmail.com";
        public string Password { get; set; } = "smkg@lance1";
    }
}