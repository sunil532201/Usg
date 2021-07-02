<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="InvoicesMaintenance.aspx.cs" Inherits="USGClient.Admin.InvoicesMaintenance" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:HiddenField  ID="hfJobID" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField  ID="hfInvoiceID" runat="server" ClientIDMode="Static"/>

    <asp:HiddenField ID="hfBalDue" runat="server" />
    <asp:HiddenField  ID="hfInvID" runat="server" />
    <asp:HiddenField  ID="hfterms" runat="server" />
<ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist" runat="server">
      <li class="nav-item">
        <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
          aria-selected="true">Outstanding</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
          aria-selected="false">Paid</a>
      </li>
       <li runat="server" id="liWeeklyCash" class="nav-item" >
           <a runat="server" class="nav-link" id="lnkWeeklyCash" href="ReportWeeklyCash.aspx">Weekly Cash Report</a></li>

    </ul> 

    
     

    <div class="card mb-3 mb-20" id="addInvoice" runat="server" >
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Invoices</span>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable2" width="100%" >
                  
                  <tbody>
                              <tr>
                                  <td><asp:DropDownList ID="ddlCustomer" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                  <td><asp:DropDownList ID="ddlJobNumber" CssClass="form-control" runat="server" onchange="SetSelectedText(this)" ></asp:DropDownList></td>
                                 <td><asp:TextBox ID="txtInvoiceNumber"   runat="server" CssClass="form-control" placeholder="Enter Invoice Number"></asp:TextBox></td>
                                  <td><asp:Button ID="btnAddInvoice" runat="server" Text="Add Invoice" CssClass="btn btn-dark" OnClick="btnAddInvoice_Click"/></td>
                              </tr>
                  </tbody>
              </table>
              
            </div>
        </div>
        <label id="lblErrorMsg" runat="server" style="color:red"></label>
    </div>

    <div class="card mb-3 mb-20" runat="server" visible="false" id="UpdateInvoiceDIv">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Invoice </span>&nbsp;&nbsp;&nbsp;
             <input type="hidden" id="jobId" value="<%=Request.QueryString["JID"]%>">
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
             <div class="table-responsive">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>Job Number: </td>
                            <td>
                                <asp:Label runat="server" ID="lblJobNumber" ></asp:Label></td>
                            
                          <td>Customer Name : </td>
                            <td>
                                <asp:Label runat="server" ID="lblCustomerID" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Invoice Date:</td>
                             <td> <asp:TextBox ID="txtInvoiceDate"   runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td>Invoice Total:</td>
                             <td> <asp:TextBox ID="txtInvoiceTotal"   runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Due Date:</td>
                             <td> <asp:TextBox ID="txtDueDate"   runat="server" CssClass="form-control"></asp:TextBox></td>
                           <td>Paid:</td>
                            <td><asp:CheckBox ID="chkPaid"  CssClass="form-checkbox" runat="server" Text="Paid " /></td>
                        </tr>
                        <tr>
                           <td>Invoice Number:</td>
                             <td><asp:Label ID="lblInvoiceNUmber" runat="server"></asp:Label></td>
                            <td>Upload Invoice</td>
                            <td><asp:FileUpload runat="server" ID="UploadPdf" AllowMultiple="true"/></td>
                            
                        </tr>
                    </tbody>
                </table>
                  <asp:LinkButton ID="lnkUpdateInvoice" TabIndex="10" runat="server" CssClass="btn btn-dark mb-10"  OnClick="lnkUpdateInvoice_Click"></asp:LinkButton>
               
                 <div class="card mb-3 mb-20" runat="server" visible="false" id="PaymentsDiv">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title">  Invoice Payment Details </span>&nbsp;&nbsp;&nbsp;
        </div>
        <div class="card-body bg-white"  runat="server">
          <div class="table-responsive">

  <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Created Date</th>
                          <th>Amount</th>
                          <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptPayments">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CreateDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("Amount") %></td>
                                  <td><asp:LinkButton runat="server" ID="EditPayment"   data-bind='<%# Eval("Amount")+","+ Eval("InvoiceID")%>'  data-toggle="modal" data-target="#UploadFileModal" OnClientClick="getProjectID(this)">Edit</asp:LinkButton></td>
                                  <td><asp:LinkButton runat="server" ID="lnkDelete" OnClientClick="return confirm('Are you sure you want to delete this Payment?');"  OnClick="lnkDelete_Click" >Delete</asp:LinkButton></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>     
     
              </div>
            </div>
                   </div>
</div>
                
               
            </div>
             
        </div>
   

       
    <div class="card mb-3" id="InvoiceLists" runat="server" >  
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Invoices List </span>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
<div class="tab-content pt-5" id="myTabContentEx">
  <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">
  <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Invoice Number</th>
                          <th>Customer Name</th>
                          <th>Invoice Date</th>
                          <th>Date Due</th>
                          <th>Job Number</th>
                          <th style="text-align:right">Invoice Total</th>
                          <th>Amount Paid</th>
                          <th>Balance Due</th>
                          <th>PaidIn Full</th>
                          <th style="text-align:center">View Invoice</th>
                          <th>Edit</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptInvoiceList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("InvoiceNumber") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("InvoiceDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DueDate","{0: MM/dd/yyyy}") %></td>
                                 <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>

                                  <td style="text-align:right">$ <%# Eval("InvoiceTotal") %></td>
                                  <td><asp:TextBox ID="txtAmountPaid" runat="server" CssClass="form-control" ClientIDMode="Static" onkeypress="return MoveNext('btnUpdateAmountDue',event.keyCode);" ></asp:TextBox><asp:LinkButton runat="server" TabIndex="0" ID="btnUpdateAmountDue" OnClick="btnUpdateAmountDue_Click"  ClientIDMode="Static"   CommandName="UpdateAmountDue" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "InvoiceID") %>'>Update</asp:LinkButton></td>
                                  <td><asp:TextBox ID="txtBalanceDue" runat="server" Text='<%# Eval("BalanceDue") %>' CssClass="form-control" ReadOnly="true"></asp:TextBox></td>
                                  <td><asp:CheckBox ID="chkPaidInFull" runat="server" CssClass="form-checkbox" Text="Paid In Full"  AutoPostBack="true" OnCheckedChanged="chkPaidInFull_CheckedChanged" /><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("InvoiceID") %>'/></td>
                                  <td style="text-align:center"><a  href="InvoicesMaintenance.aspx?url=<%# Eval("PDFURL") %>" target="_blank" >View PDF</a></td>
                                  <td><asp:LinkButton runat="server" ID="EditInvoice" class="btn btn-dark form-control" OnClick="EditInvoice_Click"    CommandArgument='<%# Eval("InvoiceTotal")+","+ Eval("CustomerID")+","+ Eval("InvoiceDate","{0: MM/dd/yyyy}")+","+ Eval("DueDate","{0: MM/dd/yyyy}")+","+ Eval("JobID")+","+ Eval("Paid")+","+ Eval("InvoiceID")+","+ Eval("CustomerName")+","+ Eval("InvoiceNumber")%>'>Edit</asp:LinkButton></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>     </div>

  <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">
  <table class="table table-bordered table-striped" id="dataTable1" width="100%" >
                  <thead>
                       <tr>
                          <th>Invoice Number</th>
                          <th>Customer Name</th>
                          <th>Invoice Date</th>
                          <th>Date Due</th>
                          <th>Job Number</th>
                          <th style="text-align:right">Invoice Total</th>
                          <th style="text-align:center">View Invoice</th>
                          <th>Edit</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptPaidList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("InvoiceNumber") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("InvoiceDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DueDate","{0: MM/dd/yyyy}") %></td>
                                 <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>
                                  <td style="text-align:right">$ <%# Eval("InvoiceTotal") %></td>
                                  <td style="text-align:center"><a  href="InvoicesMaintenance.aspx?url=<%# Eval("PDFURL") %>" target="_blank" >View PDF</a></td>
                                  <td><asp:LinkButton runat="server" ID="EditInvoice" class="btn btn-dark form-control" OnClick="EditInvoice_Click"    CommandArgument='<%# Eval("InvoiceTotal")+","+ Eval("CustomerID")+","+ Eval("InvoiceDate","{0: MM/dd/yyyy}")+","+ Eval("DueDate","{0: MM/dd/yyyy}")+","+ Eval("JobID")+","+ Eval("Paid")+","+ Eval("InvoiceID")+","+ Eval("CustomerName")+","+ Eval("InvoiceNumber")%>'>Edit</asp:LinkButton></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
  </div>
    </div>

              <asp:Button CssClass="btn btn-dark" ID="btnback" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" Text="Back" />
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
                        <b>Update Payment</b>
                    </div>
                    <div class="modal-body">
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped" cellspacing="0">
                                        <tbody>
                                            <tr>
                                                <td>Amount</td>
                                                <td>
                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" CssClass="btn btn-dark"  Text="Update" />
                    </div>

                </div>

            </div>
        </div>

    </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
         function getProjectID(input) {
            var array = input.dataset.bind.split(",");
            $("#<%=hfBalDue.ClientID%>").val(array[0]);
            $("#<%=hfInvID.ClientID%>").val(array[2]);
             $("#<%=txtAmount.ClientID%>").val(array[0]);
             return true;
        }
    </script>
   
    <script type = "text/javascript">
    function SetSelectedText(ddlFruits) {
        var selectedText = ddlFruits.options[ddlFruits.selectedIndex].innerHTML;
        document.getElementById("hfJobID").value = selectedText;
        }
       
</script>

    <script>
    // Call the dataTables jQuery plugin
        $(document).ready(function () {
           
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
        });
        $(document).ready(function () {

            $('#dataTable1').DataTable({
                "order": [[1, "asc"]]
            });
        });

    </script>

    
    <script>
$(function () {
            $("#<%=txtInvoiceDate.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date",
                beforeShow: function (input, inst) {
                    var rect = input.getBoundingClientRect();
                    setTimeout(function () {
                        inst.dpDiv.css({ top: rect.top + 40, left: rect.left + 0 });
                    }, 0);
                },

                onSelect: function(dateText, inst) {
                    var date = $(this).val();
                    getdate();
    }
            })
        });

        function getdate() {
            debugger;
            var tt = $("#<%=txtInvoiceDate.ClientID%>").val();
            var terms = $("#<%=hfterms.ClientID%>").val();
            var votevalue = parseInt(terms);
            var date = new Date(tt);
            var newdate = new Date(date);

            newdate.setDate(newdate.getDate() + votevalue);
            
            var dd = ("0" + (newdate.getDate() + 1)).slice(-2);//newdate.getDate();
            var mm = ("0" + (newdate.getMonth() + 1)).slice(-2); /*newdate.getMonth() + 1;*/
            var y = newdate.getFullYear();

            var someFormattedDate = mm + '/' + dd + '/' + y;
            $("#<%=txtDueDate.ClientID%>").val(someFormattedDate);
        }

        function MoveNext(next_ctrl, _key) {
            debugger
            if (_key == 13) {
                if ($("#txtAmountPaid").is(":focus")) {
                    var _next = document.getElementById(next_ctrl);
                    _next.click();
                    return false;
                }
            }
        }
    </script>
</asp:Content>
