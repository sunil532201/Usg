<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" AutoEventWireup="true" CodeBehind="FileTransfer.aspx.cs" Inherits="USGClient.ClientPortal.FileTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
    <h5>File transfer</h5>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
    <asp:HiddenField ID="hfProjectID" runat="server" />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">File Transfer </span>
                    <div class="float-right">
                        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#myModal">CREATE NEW PROJECT</button>
                    </div>
                </div>
                <div class="card-body bg-white">
                    <br />
                    <div>
                        <table class="table table-bordered table-striped" id="dataTable">
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
                                            <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy h:mm tt") %></td>
                                            <td ><asp:TextBox CssClass="form-control"  runat="server" onkeypress="return MoveNext('btnUpdateProjectname',event.keyCode);" ClientIDMode="Static"   ID="txtProjectname" Text='<%# Eval("ProjectName") %>'></asp:TextBox><asp:LinkButton runat="server" ID="btnUpdateProjectname" OnClick="btnUpdateProjectname_Click" ClientIDMode="Static" CommandName="UpdateProjectName" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>Update Project Name</asp:LinkButton></td>
                                    <td ><asp:TextBox CssClass="form-control"  runat="server" onkeypress="return MoveNext('btnUpdateProjectnotes',event.keyCode);" ClientIDMode="Static"   ID="txtProjectnotes" Text='<%# Eval("ProjectNotes") %>'></asp:TextBox><asp:LinkButton runat="server" ID="btnUpdateProjectnotes" OnClick="btnUpdateProjectnotes_Click" ClientIDMode="Static"   CommandName="UpdateProjectNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>Update Project Notes</asp:LinkButton></td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkViewFiles" class="btn btn-dark form-control" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'>View Files <span id="filesCount" runat="server" class="color-white font-size">(<%# Eval("Count") %>)</span></asp:LinkButton></td>
                                            <td>
                                                <button type="button" class="btn btn-dark form-control" data-bind="<%# Eval("ProjectID")%>" data-toggle="modal" data-target="#UploadFileModal" onclick="getProjectID(this)">Add Files</button></td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <br />
            </div>

        </asp:View>

        <asp:View ID="View2" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">File Transfer </span>
                </div>
                <div class="card-body table-align">
                    <div class="row mb-20">
                        <div class="col-sm-12 text-right">
                            <asp:Button class="btn btn-dark mb-10" OnClientClick="return confirm('Are you sure you want to delete this file?');" ID="btnDeleted" Text="Delete" runat="server" OnClick="btnDeleted_Click"  />  
                        </div>
                    </div>
                    <div>
                        <table class="table table-bordered table-striped" id="tblViewFiles">
                            <thead>
                                <tr>
                                    <th>Date</th>
                                    <th>File Name</th>
                                    <th>Notes</th>
                                    <th>Uploader First Name</th>
                                    <th>Uploader Last Name</th>
                                    <th>Download </th>
                                    <th>Delete</th>
                                    <th>
                                        <asp:CheckBox ID="chkHeader" runat="server" /></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptViewFiles" OnItemCommand="rptViewFiles_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy h:mm tt") %></td>
                                            <td><%# Eval("Extension").ToString() == "png" ? "<span><img src='../Assets/UserFiles/Font-Awesome/image.svg' class='fileimage'/></span>" : Eval("Extension").ToString()=="ppt"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-powerpoint.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="xls" ?"<span><img src='../Assets/UserFiles/Font-Awesome/file-excel.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="pdf"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-pdf.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="docx"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-word.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="psd"?"<span><img src='../Assets/UserFiles/Font-Awesome/adobe.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="jpg"?"<span><img src='../Assets/UserFiles/Font-Awesome/image.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="mp4"?"<span><img src='../Assets/UserFiles/Font-Awesome/video.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="pptx"?"<span><img src='../Assets/UserFiles/Font-Awesome/file-powerpoint.svg' class='fileimage' /></span>":Eval("Extension").ToString()=="ppt"?"<span><img src='../Assets/UserFiles/Font-Awesome/html5.svg' class='fileimage'/></span>":"<span><img src='../Assets/UserFiles/Font-Awesome/building.svg' class='fileimage'/></span>" %> <%# Eval("ProjectFileName")  %></td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" runat="server" onkeypress="return MoveNext('btnUpdateNote',event.keyCode);" ClientIDMode="Static"  ID="txtNotes" Text='<%# Eval("PojectFileNotes") %>'></asp:TextBox><asp:LinkButton runat="server" ID="btnUpdateNote" OnClick="btnUpdateNote_Click" CommandName="UpdateNotes" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectFileID") %>'>Update Notes</asp:LinkButton></td>
                                            <td><%# Eval("ApproverFirstName")  %></td>
                                            <td><%# Eval("ApproverLastName")  %></td>
                                            <td>
                                                <asp:LinkButton  runat="server" ID="Download" CommandName="Download" CommandArgument='<%#Eval("ImageURL")%>'>Download</asp:LinkButton></td>
                                            <td>
                                                <asp:LinkButton OnClientClick="return confirm('Are you sure you want to delete this file?');" runat="server" ID="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProjectFileID") %>'>Delete</asp:LinkButton></td>
                                            <td>
                                                <asp:CheckBox type="checkbox" ID="chkRow" runat="server" /><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("ProjectFileID") %>' />
                                            </td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
               <asp:Button CssClass="btn btn-dark buttn-paddingleft"  ID="BackViewUploads" runat="server" Text="Back" OnClick="BackViewUploads_Click"/>
            </div>
            <br />
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
            <div class="modal-dialog modal-dialog-centered">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <b>ADD FILE</b>
                    </div>
                    <div class="modal-body">
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td>Upload File</td>
                                                <td>
                                                    <div class="custom-file">
                                                        <input  type="file" id="uploadfile" multiple runat="server" />
                                                            
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnFileupload" runat="server" CssClass="btn btn-dark" OnClick="btnFileupload_Click" Text="Upload Files" />&nbsp;&nbsp;
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

    </div>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.fileDownload/1.4.2/jquery.fileDownload.min.js"></script>
    <script type="text/javascript">
         function successalert() {
            swal("Downloading Started !", "We are preparing your file, please wait...");
        }
        
        function Confirm(UrlPath) {
            $.fileDownload(UrlPath, {
                    //preparingMessageHtml: "We are preparing your file, please wait...",
                    //failMessageHtml: "There was a problem getting your file, please try again."
                });
            return false; 
        }
        
    </script>

    <script>
        $(function () {
            $("#tblViewFiles [id*=chkHeader]").click(function () {
                if ($(this).is(":checked")) {
                    $("#tblViewFiles [id*=chkRow]").attr("checked", "checked");
                } else {
                    $("#tblViewFiles [id*=chkRow]").removeAttr("checked");
                }
            });
            $("#tblViewFiles [id*=chkRow]").click(function () {
                if ($("#tblViewFiles [id*=chkRow]").length == $("#tblViewFiles [id*=chkRow]:checked").length) {
                    $("#tblViewFiles [id*=chkHeader]").attr("checked", "checked");
                } else {
                    $("#tblViewFiles [id*=chkHeader]").removeAttr("checked");
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
