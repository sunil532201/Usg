<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="FileTransfer.aspx.cs" Inherits="USGClient.Admin.FileTransfer" %>

<%--<%@ Register Src="~/Controls/AdminClientDetailsControl.ascx" TagPrefix="uc1" TagName="AdminClientDetailsControl" %>--%>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.fileDownload/1.4.2/jquery.fileDownload.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <%--<uc1:AdminClientDetailsControl runat="server" id="AdminClientDetailsControl" />--%>
     <asp:HiddenField ID="hfProjectID" runat="server"/>
     <asp:Label runat="server" ID="lblMessage"></asp:Label>
   
     <asp:MultiView ID="MultiView1" runat="server">
          <asp:View ID="UploadsList" runat="server">
           <div class="card mb-3">
        <div class="card-header">
                    <img id="logo" runat="server" class="LogoSize"/><span class="card-title">File Transfer </span>
                    <div class="float-right">
                        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#myModal">CREATE NEW PROJECT</button>
                    </div>
                </div>
        <div class="card-body" style="background-color: white !important">
                
       <div class="table-responsive">
            <table class="table table-bordered table-striped" id="dataTable" width="100%" cellspacing="0" >
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Project Name</th>
                            <th>Project Notes</th> 
                            <th>Files</th>
                            <th>Add</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptFileTransfer" OnItemCommand="rptFileTransfer_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td ><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy h:mm tt") %></td>
                                    <td ><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdateProjectname',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtProjectname" Text='<%# Eval("ProjectName") %>'></asp:TextBox><asp:LinkButton runat="server" ID="btnUpdateProjectname" OnClick="btnUpdateProjectname_Click" CommandName="UpdateProjectName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>Update Project Name</asp:LinkButton></td>
                                    <td ><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdateProjectnotes',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtProjectnotes" Text='<%# Eval("ProjectNotes") %>'></asp:TextBox><asp:LinkButton runat="server" ID="btnUpdateProjectnotes" OnClick="btnUpdateProjectnotes_Click"   CommandName="UpdateProjectNotes" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>Update Project Notes</asp:LinkButton></td>
                                    <td><asp:LinkButton runat="server" ID="lnkViewFiles" class="btn btn-dark form-control"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>View Files <span id="filesCount" runat="server" style="color:white;font-size:15px">(<%# Eval("Count") %>)</span></asp:LinkButton></td>
                                    <td><button type="button"  class="btn btn-dark form-control" data-bind="<%# Eval("ProjectID")%>" data-toggle="modal" data-target="#UploadFileModal" onclick="getProjectID(this)">Add Files</button></td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
    </div>
               </div>
           </div>
             
        </asp:View>
        <asp:View ID="ViewUploads" runat="server">
              <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i><span class="card-title"> Client File Transfer</span>&nbsp;&nbsp;&nbsp;
      <div class="float-right card-title"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["Name"]%> </div>
            <asp:Label runat="server" ID="Label2"></asp:Label>
        </div>
                 <div class="card-body" style="background-color: white !important">
           
           <div style="float:right">
               <asp:Button class="btn btn-dark mb-10" OnClientClick="return confirm('Are you sure you want to delete this file?');" ID="btnDeleted" Text="Delete" runat="server" OnClick="btnDeleted_Click" />         
                <br />
           </div>
         
                <div class="table-responsive">
            <table class="table table-bordered table-striped" id="dataTable" width="100%" cellspacing="0" class="table-striped">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>File Name</th>
                            <th>Notes</th> 
                            <th>Uploader First Name</th>
                            <th>Uploader Last Name</th>
                            <th>Download </th>
                            <th>Delete</th>
                            <th><asp:CheckBox ID="chkHeader" runat="server" /></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptViewFiles" OnItemCommand="rptViewFiles_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td ><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy h:mm tt") %></td>
                                    <td ><%# Eval("Extension").ToString() == "png" ? "<span><img src='../Assets/UserFiles/Font-Awesome/image.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>" : Eval("Extension").ToString()=="ppt"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-powerpoint.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="xls" ?"<span><img src='../Assets/UserFiles/Font-Awesome/file-excel.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="pdf"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-pdf.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="docx"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-word.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="psd"?"<span><img src='../Assets/UserFiles/Font-Awesome/adobe.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="jpg"?"<span><img src='../Assets/UserFiles/Font-Awesome/image.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="mp4"?"<span><img src='../Assets/UserFiles/Font-Awesome/video.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="pptx"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-powerpoint.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":Eval("Extension").ToString()=="ppt"?"<span><img src='../Assets/UserFiles/Font-Awesome/html5.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>":"<span><img src='../Assets/UserFiles/Font-Awesome/building.svg' style='height: 30px; width: 30px;color:#0088cc'/></span>" %> <%# Eval("ProjectFileName")  %></td>
                                    <td ><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdateNote',event.keyCode);" ClientIDMode="Static" runat="server"   ID="txtNotes" Text='<%# Eval("PojectFileNotes") %>'></asp:TextBox><asp:LinkButton runat="server" TabIndex="0" ID="btnUpdateNote" OnClick="btnUpdateNote_Click" ClientIDMode="Static"   CommandName="UpdateNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectFileID") %>'>Update Notes</asp:LinkButton></td>                                    
                                    <td><%# Eval("ApproverFirstName")  %></td>
                                    <td><%# Eval("ApproverLastName")  %></td>
                                    <td><asp:LinkButton OnClientClick="successalert();" runat="server" ID="Download" CommandName="Download"  CommandArgument='<%#Eval("ImageURL")%>'>Download</asp:LinkButton></td>
                                    <td><asp:LinkButton   OnClientClick="return confirm('Are you sure you want to delete this file?');" runat="server" ID="lnkDelete" CommandName="Delete"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectFileID") %>'>Delete</asp:LinkButton></td>
                                    <td><asp:CheckBox  type="checkbox" ID="chkRow" runat="server" /><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("ProjectFileID") %>'/></td>
                                </tr>
                             </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
    </div>
              <asp:Button CssClass="btn btn-dark" ID="BackViewUploads" runat="server" Text="Back" OnClick="BacktoViewUploads_Click"/>
               </div>
                     </div>
        </asp:View>
         </asp:MultiView>
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-dialog-centered">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <b>ADD PROJECT</b>
                    </div>
                    <div class="modal-body">
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped" cellspacing="0">
                                        <tbody>
                                            <%--<tr>
                                                <td>Customer Name</td>
                                                <td><asp:DropDownList ID="ddlCustomerName" TabIndex="0" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                            </tr>--%>
                                            <tr>
                                                <td>Project Name</td>
                                                <td>
                                                    <input class="form-control" type="text" id="txtProjectName" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Project Notes</td>
                                                <td>
                                                    <input class="form-control" type="text" id="txtProjectNotes" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="CreateProject" runat="server" CssClass="btn btn-dark" OnClick="CreateProject_Click" Text="Create Project" />&nbsp;&nbsp;
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

    </div>
     <div class="container">
  <!-- Modal -->
  <div class="modal fade" id="UploadFileModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <b>ADD FILE</b>
        </div>
        <div class="modal-body">
          <div class="card mb-3">
        <div class="card-body" style="background-color: white !important">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                        <td>Upload File</td>
                        <td>
                            <input class="form-control"  type="file" id="uploadfile" multiple runat="server"/>
                        </td>
                        </tr>
                    </tbody>
                </table>
                </div>
            </div>
              </div>
        </div>
        <div class="modal-footer">
          <asp:Button ID="btnFileupload" runat="server" CssClass="btn btn-dark" OnClick="btnFileupload_Click" Text="Upload Files" /><button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  
</div>
     <script src="../vendor/jquery/jquery.min.js"></script>
     <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.fileDownload/1.4.2/jquery.fileDownload.min.js"></script>
      <script>
        function Confirm(UrlPath) {
            $.fileDownload(UrlPath, {
                    //preparingMessageHtml: "We are preparing your file, please wait...",
                    //failMessageHtml: "There was a problem getting your file, please try again."
                });
            return false; 

          }

    </script>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

   <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    
     <script type="text/javascript">
         function successalert() {
             swal("Downloading Started !", "Please wait while we process your request");
       
         }
     </script>
    
    <script>
        // Delete All Checked Checkboxes Script
$(function () {
    $("#dataTable [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#dataTable [id*=chkRow]").attr("checked", "checked");
            } else {
                $("#dataTable [id*=chkRow]").removeAttr("checked");
            }
        });
        $("#dataTable [id*=chkRow]").click(function () {
            if ($("#dataTable [id*=chkRow]").length == $("#dataTable [id*=chkRow]:checked").length) {
                $("#dataTable [id*=chkHeader]").attr("checked", "checked");
            } else {
                $("#dataTable [id*=chkHeader]").removeAttr("checked");
            }
        });
        });

        function getProjectID(input) {
            $("#<%=hfProjectID.ClientID%>").val(input.dataset.bind); // Get ProductID  On Clicking ADD Files Button  
          
        }
        
        function MoveNext(next_ctrl, _key) {
                debugger
            if (_key == 13) {
                if ($("#txtNotes").is(":focus")) {
                    var _next = document.getElementById(next_ctrl);
                    _next.click();
                    return false;
                }
                if ($("#txtProjectname").is(":focus")) {
                    var _next = document.getElementById(next_ctrl);
                    _next.click();
                    return false;
                }
                if ($("#txtProjectnotes").is(":focus")) {
                    var _next = document.getElementById(next_ctrl);
                    _next.click();
                    return false;
                }
                }
             }
       
    </script>

</asp:Content>
