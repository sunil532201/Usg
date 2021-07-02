using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace USGClient.Admin
{
    public partial class LayoutUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            AdminDetails.LayoutsActive = true;
            if (!Page.IsPostBack)
            {
            }
        }
        #region Methods

        private void LoadClientDetails(Int32 _nCustomerID)
        {

            USGData.Customer objCustomer = new USGData.Customer(_nCustomerID);
            string name = objCustomer.CustomerName;
            Session["Name"] = name;
        }

        private void CreateLayout(Int32 _nCustomerID, String _strFileName, String _strTitle, String _strPromoMonth, String _strPromoYear, String _strOrder, String _strImageUrl)
        {
            String[] arrAdminUser = Context.User.Identity.Name.Split('~');
            var isRecordUpdate = false;
            if (_nCustomerID > 0)
            {
                Int32 nMockupID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);
                //TO DO: do a search in the Mockup Table.  If there is a record with the same OrderNumber,
                //Title, Promo Month and Promo Year then Set MockupID to the found record.

                if (nMockupID == 0)
                {
                    USGData.Mockup objMockup = new USGData.Mockup();
                    objMockup.CustomerID = _nCustomerID;
                    objMockup.Title = _strTitle.Replace("'", ".");
                    objMockup.PromoMonth = USGData.Conversion.ConvertToInt32(_strPromoMonth);
                    objMockup.PromoYear = USGData.Conversion.ConvertToInt32(_strPromoYear);
                    objMockup.ApprovalDate = Convert.ToDateTime("1/1/1900");
                    objMockup.OrderNumber = _strOrder;

                    isRecordUpdate = objMockup.IsRecordExists(objMockup, out nMockupID);
                    if (isRecordUpdate)
                    {
                        USGData.Mockup objMockups = new USGData.Mockup(nMockupID);
                        objMockup.CreateDate = objMockups.CreateDate;
                        objMockup.MockupID = nMockupID;
                        objMockup.Update();
                    }
                    else
                    {
                        objMockup.CreateDate = DateTime.Now;
                        nMockupID = objMockup.Create();
                    }
                }

                //int nMockUpNoteID = 0;
                USGData.MockupNote objMockupNote = new USGData.MockupNote();
                objMockupNote.CreateDate = DateTime.Now;
                objMockupNote.Image = _strFileName;
                objMockupNote.MockupID = nMockupID;
                objMockupNote.MockupNoteTypeID = 2;
                if (txtComment.Text.Trim().Length > 0)
                {
                    objMockupNote.Notes = txtComment.Text.Trim();
                }
                else
                {
                    objMockupNote.Notes = "Please review and note any changes.";
                }
                USGData.Administrator objAdministrator = new USGData.Administrator(USGData.Conversion.ConvertToInt32(arrAdminUser[0]));
                objMockupNote.AdministratorID = objAdministrator.AdministratorID;
                objMockupNote.ImageUrl = _strImageUrl;
                //if (objMockupNote.IsRecordExists(objMockupNote, out nMockUpNoteID))
                //{
                //    objMockupNote.MockupNoteID = nMockUpNoteID;
                //    objMockupNote.Update();
                //}
                //else
                //{
                objMockupNote.Create();
                //}
                string cid = Request.QueryString["CID"].ToString();
            }
        }

        #endregion

        #region GUI Handlers        
        protected void lnkSaveFile_Click(object sender, EventArgs e)
        {

            try
            {
                Int32 nMockupID = USGData.Conversion.ConvertToInt32(Request.QueryString["MID"]);

                //12172018_082748_26361_5x7-Cooler-Door-Decal-Core-Water-20oz_12-2018
                // USGData.CustomerUser objUser = new USGData.CustomerUser(USGData.Conversion.ConvertToInt32(ddlCustomerUsers.SelectedValue));
                HttpFileCollection httpFileCollection = Request.Files;
                for (int i = 0; i < httpFileCollection.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpFileCollection[i];
                    String imgFileName = "";
                    String strUploadDate = "";
                    String strOrder = "";
                    String strTitle = "";
                    String strPromoMonth = "";
                    String strPromoYear = "";



                    if (httpPostedFile.ContentLength > 0)
                    {
                        if(nMockupID > 0)
                        {

                       String[] split = httpPostedFile.FileName.Split('.');
                            String[] arrFileName = httpPostedFile.FileName.Split('_');
                             strOrder = arrFileName[0];
                             strTitle = arrFileName[1];
                            String[] arrPromoDate = arrFileName[2].Split('-');
                             strPromoMonth = arrPromoDate[0];
                             strPromoYear = arrPromoDate[1].Substring(0, 4);



                            //string[] imageName = split[0].Split('/');
                        string type = split[1];
                        string exactName = split[0];
                        string[] FinalName = exactName.Split('_');
                        int length = FinalName.Length;
                        string[] a = FinalName[length - 1].Split('_');
                        string FileName = exactName;
                        if (a.Length > 1)
                        {
                            FileName = FileName.Remove(FileName.Length - 2, 2);
                        }

                        USGData.MockupNote objMockupNote = new USGData.MockupNote();

                        DataView dv = objMockupNote.GetFileName(nMockupID,FileName).DefaultView;
                        int nCount = USGData.Conversion.ConvertToInt32(dv[0]["Filename"]);
                        string strFileName = "";

                        if (nCount == 0)
                        {

                            strFileName = exactName + "." + type;
                        }

                        else if (nCount == 1)
                        {
                            strFileName = exactName + "_1" + "." + type;

                        }
                        else
                        {
                            strFileName = exactName.Remove(exactName.Length - 1, 1) + nCount + "." + type;

                        }


                            imgFileName = strFileName;
                            strUploadDate = DateTime.Now.ToString("MMddyyyy~hhmmss~");


                        }
                        else
                        {
                            String[] arrFileName = httpPostedFile.FileName.Split('_');    // 11111_20x13-Pallet-Sign-Zephyrhills_3-2020
                             strOrder = arrFileName[0];
                             strTitle = arrFileName[1];
                            String[] arrPromoDate = arrFileName[2].Split('-');
                             strPromoMonth = arrPromoDate[0];
                             strPromoYear = arrPromoDate[1].Substring(0, 4);



                            //Save Original Image
                            String strPath = Server.MapPath(ConfigurationManager.AppSettings["IMAGEBASEURL"] + strPromoMonth + "_" + strPromoYear + "/");
                            String strThumbPath = Server.MapPath(ConfigurationManager.AppSettings["IMAGEBASEURL"] + strPromoMonth + "_" + strPromoYear + "/Thumbs/");
                            //String FileName = Path.GetFileName(httpPostedFile.FileName);
                             imgFileName = Path.GetFileName(httpPostedFile.FileName);





                            //Check to see if Directory Exists
                            if (!System.IO.Directory.Exists(strPath))
                            {
                                System.IO.Directory.CreateDirectory(strPath);
                                System.IO.Directory.CreateDirectory(strThumbPath);
                            }
                            //Save Thumbnail
                             strUploadDate = DateTime.Now.ToString("MMddyyyy~hhmmss~");
                            httpPostedFile.SaveAs(strPath + strUploadDate + imgFileName.Replace(" ", string.Empty));

                            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(strPath + strUploadDate + imgFileName.Replace(" ", string.Empty));
                            int X = originalImage.Width;
                            int Y = originalImage.Height;
                            int height = (int)((120 * Y) / X);
                            int width = (int)((90 * X) / Y);
                            if (X > Y)
                            {
                                originalImage = originalImage.GetThumbnailImage(120, height, null, IntPtr.Zero);
                            }
                            else
                            {
                                originalImage = originalImage.GetThumbnailImage(width, 90, null, IntPtr.Zero);
                            }
                            originalImage.Save(strThumbPath + strUploadDate + imgFileName.Replace(" ", string.Empty), originalImage.RawFormat);

                        }


                        //---------------Saving Image to Azure Blob Storage----------//
                        Stream fs = httpPostedFile.InputStream;

                        BinaryReader br = new BinaryReader(fs);
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        string accountName = System.Configuration.ConfigurationManager.AppSettings["storageAccountName"];
                        string keyValue = System.Configuration.ConfigurationManager.AppSettings["storageKeyValue"];

                        StorageCredentials creden = new StorageCredentials(accountName, keyValue);

                        Microsoft.WindowsAzure.Storage.CloudStorageAccount acc = new Microsoft.WindowsAzure.Storage.CloudStorageAccount(creden, useHttps: true);

                        CloudBlobClient client = acc.CreateCloudBlobClient();
                        CloudBlobContainer cont = client.GetContainerReference("usgfiles");

                        cont.CreateIfNotExists();

                        cont.SetPermissions(new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        });
                        CloudBlockBlob cblob = cont.GetBlockBlobReference(imgFileName.Replace(" ", string.Empty));
                        Stream fileStream = new MemoryStream(bytes);
                        cblob.UploadFromStreamAsync(fileStream);
                        string ImageUrl = Convert.ToString(cblob.Uri);

                        //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                        //// Create a reference to the blob
                        //CloudBlob blob = cont.GetBlobReference(imgFileName.Replace(" ", string.Empty));
                        //// Set the CacheControl property to expire in 1 hour (3600 seconds)
                        //blob.Properties.CacheControl = "max-age=60";
                        //// Update the blob's properties in the cloud
                        //blob.SetProperties();

                        CreateLayout(Convert.ToInt32(Request.QueryString["CID"]), strUploadDate + imgFileName.Replace(" ", string.Empty), strTitle, strPromoMonth, strPromoYear, strOrder, ImageUrl);
                    }
                }
                Response.Redirect("Layouts.aspx?CID=" + Request.QueryString["CID"]);
            }
            catch (Exception exp)
            {
                lblMessage.Text = "An error has occurred.  Please try again." + exp.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion


    }
}