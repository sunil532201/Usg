<%@ Page Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="USGClient.Order" %>
<%--<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
        <style>

.checkbox-menu li label {
    display: block;
    padding: 3px 10px;
    clear: both;
    font-weight: normal;
    line-height: 1.42857143;
    color: #333;
    white-space: nowrap;
    margin:0;
    transition: background-color .4s ease;
}
.checkbox-menu li input {
    margin: 0px 5px;
    top: 2px;
    position: relative;
}

.checkbox-menu li.active label {
    background-color: #cbcbff;
    font-weight:bold;
}

.checkbox-menu li label:hover,
.checkbox-menu li label:focus {
    background-color: #f5f5f5;
}

.checkbox-menu li.active label:hover,
.checkbox-menu li.active label:focus {
    background-color: #b8b8ff;
}
    </style>

    <h5>Store Ordering</h5>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    
    <asp:Label runat="server" ID="lblMessage"></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <div class="row">
                        <div class="col-sm-6">
                            <i class="fa fa-table "></i><span class="card-title">Store Ordering </span>
                        </div>
                        <div class="col-sm-6 text-right">
                            <div class="flow-root">
                                <a href="#" runat="server" onclick="showConfirm(event);" onserverclick="Cart_Click"><i class="fa fa-shopping-cart fa-w-18 fa-3x float-right" aria-hidden="true"></i>
                                    <div class="CartPosition float-right"><span runat="server" id="cartCount"></span></div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="form-group">
<%--                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Name" required="" ID="txtName" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Phone Number" required="" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" placeholder="PO Number (N/A if not applicable)" required="" ID="txtPONumber" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" placeholder="Previous Job Number" ID="txtPreviousJobNumber" runat="server"></asp:TextBox>
                            </div>
                        <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" placeholder="Need Date" ID="txtDateNeeded" runat="server"></asp:TextBox>
                            </div>
                             <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" placeholder="Need Date" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredPhoneNumber" EnableClientScript="True" runat="server" ControlToValidate="txtPhoneNumber" Display="Dynamic" ErrorMessage="Please select a Phone Number" ForeColor="Red"></asp:RequiredFieldValidator>  

                        </div>
                        </div>
                       
                        </div>
                        <div class="row">
<%--                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Email Address" required="" ID="txtEmail" runat="server"></asp:TextBox>
                            </div>--%>
                        </div>
                        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" CssClass="btn btn-dark mr-xs mb-sm pl-10"></asp:Button>
                        <br />
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">

            <div class="card mb-3">
                <div class="card-header">
                   <div class="row">
                        <div class="col-sm-6">
                            <i class="fa fa-table "></i><span class="card-title">Store Ordering </span>
                        </div>
                        <div class="col-sm-6 text-right">
                            <div class="flow-root">
                                <a href="#" runat="server" onclick="showConfirm(event);" onserverclick="Cart_Click"><i class="fa fa-shopping-cart fa-w-18 fa-3x float-right" aria-hidden="true"></i>
                                    <div class="CartPosition float-right"><span runat="server" id="cardCountForStoreOrder"></span></div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body table-striped">
                    <div class="form-group ">


                        <div class="row">
                            
                            <div class="col-md-6" id="ManagerOrder" runat="server" visible="false">
                                Ship To Store Number:
                                <asp:ListBox ID="StoreNumberList" runat="server"  required="" SelectionMode="Multiple">
                                </asp:ListBox>
                            </div>
                             <div class="col-md-6" id="StoreOrder" runat="server" visible="false">
                                <asp:DropDownList  CssClass="form-control" ID="ddlStoreNumberList" runat="server" AutoPostBack="True"
                               AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedIndexChanged" required="" >
<%--                                <asp:ListItem Text="Please Select Store Number" Value=""></asp:ListItem>--%>

                                </asp:DropDownList>
                            </div>

                           
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:DropDownList required="" CssClass="form-control" ID="ddlSignType" runat="server">
                                    <asp:ListItem Text="Please Select Sign Type" Value=""></asp:ListItem>
                                </asp:DropDownList>

                                <asp:TextBox ID="txtOrderImageUrl" runat="server" Text="" Style="display: none"></asp:TextBox>
                                <!--to save the clicked ImageUrl-->
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Promotion" required="" ID="txtPromotion" runat="server"></asp:TextBox>
                            </div>
                        </div>
                       
                        <div class="row">
                           <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Quantity" required="" ID="txtQuan" runat="server"></asp:TextBox>

                            </div>

                            <div class="col-md-6">
                                <asp:TextBox CssClass="form-control" placeholder="Reason For Order" required="" ID="txtReason" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-10">
                            <div class="col-md-10">
                                If you can't take a picture you can search previous approved orders to find your item.
                            </div>
                        </div>
                        <div class="row item-center">
                            <div class="col-md-6">
                                <div class="custom-file">
                                    <asp:FileUpload ID="FileUpload2" multiple="multiple" onchange="showpreview(this);" runat="server" CssClass="custom-file-input" />               
                                    <label class="custom-file-label" for="customFileLangHTML" data-browse="Browse">
                                        Choose file</label>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <p id="imgTxt">Selected Image</p><img src=""  id="displayImg"  class=" image-maxheight" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtPromotext" CssClass="form-control" placeholder="Search For Approved Images"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton OnClientClick="ClearFileUpload();" CssClass="btn btn-dark  mr-xs mb-sm" Text="Search" runat="server" ID="lnkSearch" OnClick="lnkSearch_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row recordCount">
                            <div class="col-sm-12 text-sm-right">
                                <asp:Label runat="server" ID="lblCount" EnableViewState="false"></asp:Label>
                            </div>
                        </div>

                        <div class="mockupContainer">
                            <div runat="server" id="divLightbox" enableviewstate="false" >
                                <asp:Repeater runat="server" ID="rptList">
                                    <ItemTemplate>
                                        <div class="col-sm-4 float-left">
                                            <div class="ImageContainer">
                                                <a class="img-thumbnail mb-xs mr-xs SelectImg" href='<%# GetURL(Eval("MockupNoteID"),Eval("MockupID"))%>'>
                                                    <%# GetImage(Eval("MockupNoteID"), Eval("MockupID")) %>
                                                </a>
                                            </div>
                                            <div class="PromoDateContainer">
                                                <%#Eval("PromoMonth") + "-" + Eval("PromoYear") %>
                                            </div>
                                            <div class="MockNameContainer">
                                                <%#Eval("Title") %>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                    </div>

                    <div>
                        <asp:Image runat="server" ID="Update_Image" CssClass="" Visible="false" />
                        <img id="imgpreview" style="padding-left:20px" class="prev-img" />
                    </div>
                    <div class="mt-20">
                        <asp:Button ID="btnAddOrder" style="margin-left:20px" runat="server" Text="Add To Order" OnClick="btnAddOrder_Click" CssClass="btn btn-dark mr-xs mb-sm AddOrder" />
                    </div>
                    <hr class="mt-40" />
                    <div style="margin-left:20px">
                        <h2 class="mb-20 mt-20">Submit Order For Review</h2>
                        <div class="mb-20">
                            Once you have added all your items to your order submit your order below by clicking on Review Order.
                        </div>
                    </div>
                    <div>
                        <asp:LinkButton ID="LinkBtnReviewOrder" style="margin-left:20px;margin-bottom:20px" Text="Review Order" runat="server" OnClick="LinkbtnReviewOrder_Click" CssClass="btn btn-dark mr-xs mb-sm"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <div id="myModalImage" class="modalImage">
                <span class="closeImage">&times;</span>
                <img class="modalImage-content" id="img01" />
                <div id="caption"></div>
            </div>
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Store Ordering </span>
                </div>
                <div class="card-body bg-white ">

                    <div class="table-responsive">
                        <table class="table table-bordered table-striped">
                            <tr>
                                <td colspan="2"><strong>Customer Info</strong></td>
                            </tr>
<%--                            <tr>
                                <td>Name:</td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Phone Number:</td>
                                <td>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label></td>
                            </tr>--%>
                            <tr>
                                <td>PO Number:</td>
                                <td>
                                    <asp:Label ID="lblPoNumber" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Previous Job Number:</td>
                                <td>
                                    <asp:Label ID="lblPreviousNumber" runat="server" Text=""></asp:Label></td>
                            </tr>
                             <tr>
                                <td>Need Date :</td>
                                <td>
                                    <asp:Label ID="lblDateNeeded" runat="server" Text=""></asp:Label></td>
                            </tr>
<%--                            <tr>
                                <td>Email Address:</td>
                                <td>
                                    <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label></td>
                            </tr>--%>
                        </table>
                        <br />

                        <div class="text-sm-right mr-10">
                            <asp:LinkButton runat="server" ID="lnkAddMoreItems" Text="Add More Items" CssClass="btn btn-dark" OnClick="lnkAddMoreItems_Click"></asp:LinkButton>
                        </div>
                        <div class="card-title"><strong>Items</strong></div>


                        <div class="table-responsive">
                            <table class="table table-bordered table-striped" id="dataTable" width="100%">
                                <thead>
                                    <tr>
                                        <th>Sign Type</th>
                                       <%-- <th>Size</th>--%>
                                        <th>Quantity</th>
                                        <th>Promotion</th>
                                        <th>Order Reason</th>
                                        <th>Ship To Store Number</th>
                                        <th>Image</th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rptReviewGrid" OnItemCommand="rptReviewGrid_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("SignType") %></td>
                                               <%-- <td><%# Eval("SignTypeSize") %></td>--%>
                                                <td><%# Eval("Quantity") %></td>
                                                <td><%# Eval("Promotion") %></td>
                                                <td><%# Eval("OrderReason") %></td>
                                                <td><%# Eval("ShipToStoreNumber")%></td>
                                                <td><a href='<%# Eval("ImageUrl")%>'>
                                                    <img class="img-thumbnail" style="width:100px; height:100px" src='<%# Eval("ImageUrl")%>'></a>
                                                </td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="lnkEdit" OnClick="lnkEdit_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderedItemID")%>'>Edit</asp:LinkButton></td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="lnkDelete" OnClick="lnkDelete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderedItemID") %>'>Delete</asp:LinkButton></td>
                                                </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <span class="ml-10">
                            <asp:Button ID="btnCompleteOrder" runat="server" Text="Complete Order" OnClick="btnCompleteOrder_Click" CssClass="btn btn-dark mr-xs mb-sm" /></span>
                        <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel Order" OnClick="btnCancelOrder_Click" CssClass="btn btn-dark mr-xs mb-sm" />
                    </div>
                    <br />
                </div>
            </div>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <div class="card mb-3">
                <div class="card-header noprint">
                    <i class="fa fa-table "></i><span class="card-title">Store Ordering </span>
                </div>
                <div class="card-body bg-white">
                    <div class="PrintPage">
                        <div class="ml-10" style="margin-left:45px;">

                                <img id="logo" runat="server" style="margin-bottom: 10px;" class="LogoSize"/> <span class="card-title" style="font-size:30px;" runat="server" id="CustomerName"></span>&nbsp;&nbsp;&nbsp;
                                </br>
                                <h4 style='display:inline;'>Thank You.  Your order has been placed.</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table table-bordered table-striped">
                                    <tr>
                                        <td colspan="2"><strong>Customer Info</strong></td>
                                    </tr>
                                    <tr>
                                        <td>PO Number:</td>
                                        <td><asp:Label ID="lblPoNumber1" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Previous Job Number:</td>
                                        <td><asp:Label ID="lblPreviousJobNumber" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Need Date :</td>
                                        <td><asp:Label ID="lblNeedDate" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Ordered By :</td>
                                        <td><asp:Label ID="lblOrderedBy" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>New Job Number :</td>
                                        <td><asp:Label ID="lblNewJobNumber" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                                <br />
                                <div class="card-title"><strong>Items</strong></div>
                                <asp:GridView ID="gvOrderGrid1" SelectedIndex="1" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderedItemID" CssClass="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField DataField="SignType" HeaderText="Sign Type" />
                                       <%-- <asp:BoundField DataField="SignTypeSize" HeaderText="Size" />--%>
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                        <asp:BoundField DataField="Promotion" HeaderText="Promotion" />
                                        <asp:BoundField DataField="OrderReason" HeaderText="Order Reason" />
                                        <asp:BoundField DataField="ShipToStoreNumber" HeaderText="Ship To Store Number" />
                                        <asp:ImageField ControlStyle-CssClass="square-thumb" DataImageUrlField="ImageUrl" HeaderText="Image" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <style>
                            @media print {
                                .noprint {
                                    display: none;
                                }
                            }
                        </style>
                        <div class="noprint ml-10">
                            <a id="PrintPage" href="#" class="btn btn-dark">Print</a>
                        </div>
                        <br />
                    </div>
                </div>
                <%-- </div>--%>
            </div>
        </asp:View>
    </asp:MultiView>



   <%-- <script type="text/javascript">

        function PopulateSignTypeSize() {
            $("#<%=ddlSignTypeSize.ClientID%>").attr("disabled", "disabled");
            if ($('#<%=ddlSignType.ClientID%>').val() == "0") {
                $('#<%=ddlSignTypeSize.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
            }
            else {
                $('#<%=ddlSignTypeSize.ClientID %>').empty().append('<option selected="selected" value="0">Loading....</option>');
                $.ajax({
                    type: "POST",
                    url: 'Order.aspx/PopulateSignTypeSize',
                    data: '{SignTypeID: ' + $('#<%=ddlSignType.ClientID%>').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnPopulateSignTypeSize,
                    failure: function (response) {
                        alert(response.d);
                    }

                });
            }
        }
        function OnPopulateSignTypeSize(response) {
            console.log(response);
            PopulateControl(response.d, $("#<%=ddlSignTypeSize.ClientID %>"));
        }

        function PopulateControl(list, control) {
            console.log(control);
            console.log(list);
            if (list.length > 0) {
                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">Please select</option>');
                for (var i = 0; i < list.length; i++) {

                    control.append($("<option></option>").val(list[i]['SignTypeSizeID']).html(list[i]['SignTypeSize']));
                }
            }
            else {
                control.empty().append('<option selected="selected" value="0">Not available<option>');
            }
        }
    </script>--%>

    <script src="../js/printThis.js"></script>
<%--    <link rel="stylesheet" href="css/bootstrap-3.1.1.min.css" type="text/css" />
<link rel="stylesheet" href="css/bootstrap-multiselect.css" type="text/css" />
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="js/bootstrap-2.3.2.min.js"></script>
<script type="text/javascript" src="js/bootstrap-multiselect.js"></script>--%>


     
  <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    

   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
   <script src="../js/jquery.sumoselect.min.js"></script>
   <link href="../css/sumoselect.css" rel="stylesheet">
       <link href="../css/sumoselect.min.css" rel="stylesheet">

      <script type="text/javascript">
          $(<%=StoreNumberList.ClientID%>).SumoSelect();

      </script>

    <script type="text/javascript">
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $('#PrintPage').click(function () {
               // $(".PrintPage").printThis();
                window.print();
           return false;
            });

            $('#<%=txtDateNeeded.ClientID%>').datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date"
            })

        });

        //document.getElementById('ContentFooter').style.minHeight = "0px";
        $('#ContentFooter').css('min-height', '0px');
        

    </script>

    <!---------NEW SCRIPTS---------->

    <script type="text/javascript">
        //--------Display Preview of Uploaded image
        function showpreview(input) {
            debugger
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("#<%=Update_Image.ClientID%>").attr('style', 'display: none;height: 200px;width: 200px;');
                    $('#imgpreview').show();
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                $("#<%=txtOrderImageUrl.ClientID%>").val(""); // Undoing the Selected Approved Image  
                $("#<%=divLightbox.ClientID%>").attr('style', 'display: none;'); // To hide Lightbox div  

                reader.readAsDataURL(input.files[0]);
            }
        }


        //------Hiding preview if Img Src is Null
        $(document).ready(function () {
            $("#<%=Update_Image.ClientID%>").attr('style', 'height: 200px;width: 200px;');
            $('#imgpreview[src=""]').hide();
        });

        //------Get Img Src of Selected Approved image 
        $(document).ready(function () {
            debugger
            document.getElementById('ContentFooter').style.minHeight = "0px";

            $(".imageClass").on("click", function (e) {
                e.preventDefault();
                var src = this.src;
                $("#<%=txtOrderImageUrl.ClientID%>").val(src);
                $('#displayImg').attr("src", src);
                $('.mockupContainer').hide();
                $("#displayImg").show();
                $('#imgTxt').hide();
                $('.recordCount').hide();
            });
        });

        $(document).ready(function () {
                $("#displayImg").hide();
        });

        function ClearFileUpload() {
            $('#imgpreview').attr('src', "");
            $('#imgpreview[src=""]').hide();
        }

        $('.SelectImg').click(function () {
            $('.selected').removeClass('selected');
            $(this).toggleClass('selected');
        });

        function showConfirm(event) {
            debugger;
            var divTxt = $(event.target).text();
            var count = $("#<%=cartCount.ClientID%>").text();
            if (divTxt == 0 && count == 0) {
                alert("Sorry , No item's found");
                event.preventDefault();
                return false;
            }
            else {
                return true;
            }
        }
       
    </script>
    <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".img-thumbnail").on("click", function (e) {
                e.preventDefault();
                debugger;
                var modal = document.getElementById("myModalImage");
                // Get the image and insert it inside the modal - use its "alt" text as a caption
                var img = document.getElementById(e.target.id);
                var modalImg = document.getElementById("img01");
                var captionText = document.getElementById("caption");
                //img.onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
                //captionText.innerHTML = this.alt;
                //}
                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("closeImage")[0];

                // When the user clicks on <span> (x), close the modal
                span.onclick = function () {
                    modal.style.display = "none";
                }
                //}
            });
        });
    </script>

 
</asp:Content>



