<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Delivery_Challan.aspx.cs" Inherits="Admin_Estimate_Challan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-heading">
        <h4 class="text-center">Delivery Challan</h4>
    </div>
    <style>
        .grid-SrNo, .grid-Delete, .grid-Qty, .grid-Rate {
            width: 10%;
            text-align: center;
        }

        .grid-TotalAmt {
            width: 15%;
            text-align: center;
        }

        .grid-ItemName {
            width: 45%;
            text-align: center;
        }

        .grid-column input, .grid-column label {
            width: 100%;
            box-sizing: border-box;
        }

        .grid-header {
            text-align: center;
            background-color: #34495e;
            color: azure;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>Delivery Challan
                        </h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-3 mb-3">
                                    <label for="txtDate">
                                        Date:</label>

                                    <asp:TextBox  ID="txtDate" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <label for="txtCustumerName">
                                        Customer Name:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtCustumerName">
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ValidationGroup="ValidationGA" runat="server" Display="Dynamic"
                                        ErrorMessage="Customer Name Incorrect Format " ForeColor="Red" ControlToValidate="txtCustumerName"
                                        ValidationExpression="^[A-Za-z ]{1,}$"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValidationGA"
                                        runat="server" ControlToValidate="txtCustumerName" Display="Dynamic" ErrorMessage=" Customer Name is Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <label for="txtMobileNumber">
                                        Mobile Number:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" MaxLength="10"
                                        ID="txtMobileNumber">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValidationGA"
                                        runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ErrorMessage="Mobile Number is Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <label for="txtAddress">
                                        Address:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtAddress">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="ValidationGA"
                                        ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Address is Required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ValidationGroup="ValidationGA" runat="server" Display="Dynamic"
                                        ErrorMessage="Address format Incorrect" ForeColor="Red" ControlToValidate="txtAddress"
                                        ValidationExpression="^[A-Za-z0-9,-. ]{1,100}$"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 mb-3">
                                    <label for="txtItemName">
                                        Item Name:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtItemName">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ValidationGA"
                                        runat="server" ControlToValidate="txtItemName" Display="Dynamic" ErrorMessage="Item Name is Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <label for="txtQuantity">
                                        Item Qty:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtQuantity"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ValidationGA"
                                        Display="Dynamic" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please enter a valid quantity."
                                        ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ValidationGA"
                                        runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Item Qty is Required">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <label for="txtRate">
                                        Remark:</label>
                                    <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtRemark"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ValidationGA"
                                        runat="server" ControlToValidate="txtRemark" Display="Dynamic" ErrorMessage="Remark is Required">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-3">
                                    <div class="btn-toolbar" style="margin-top: 3rem;">
                                        <asp:Button runat="server" Text="Add" ValidationGroup="ValidationGA" ID="btnAdd"
                                            OnClick="btnAdd_onClick" class="btn btn-outline-success" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>Bill Information</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <asp:Panel ID="pnlReceiptData" runat="server" Visible="false">
                                    <asp:GridView runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false" OnRowCommand="grdReceiptData_RowCommand" ID="grdReceiptData">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="grid-Delete" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lblDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Container.DataItemIndex %>'>Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item Name" ItemStyle-CssClass="grid-ItemName" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-CssClass="grid-Qty" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="lblQty" runat="server" Text='<%# Eval("Qty") %>' onchange="updateTotal(this)"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remark" ItemStyle-CssClass="grid-Remark" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Qty" ItemStyle-CssClass="grid-Qty" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalQty" runat="server" Text='<%# Eval("TotalQty") %>' onchange="updateTotal(this)"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <!-- Total Qty Table -->
                                    <div class="total-qty-section">
                                        <table class="table table-bordered">
                                            <tr>
                                                <th>Total Qty:</th>
                                                <td>
                                                    <asp:Label ID="lbltotqty" runat="server" Text="0"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                    <br />
                                    <div class="col-sm-12" style="text-align: right;">
                                        <asp:Button runat="server" Text="Submit" ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_onClick"
                                            Visible="false" />
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function updateTotal(element) {
            const row = element.closest('tr');
            const qtyInput = row.querySelector('[id$=lblQty]');
            const qty = parseFloat(qtyInput.value) || 0;

            const total = qty;

            row.querySelector('[id$=lblTotalQty]').innerText = total.toFixed(2);

            updateOverallTotals();
        }

        function updateOverallTotals() {
            let totalQuantity = 0;
            let totalAmount = 0.0;

            const rows = document.querySelectorAll('#<%= grdReceiptData.ClientID %> tr');

        rows.forEach((row, index) => {
            if (index === 0) return;

            const qty = parseFloat(row.querySelector('[id$=lblQty]').value) || 0;

            const rowTotal = parseFloat(row.querySelector('[id$=lblTotalQty]').innerText) || 0;

            totalQuantity += qty;
            totalAmount += rowTotal;
        });

        document.getElementById('<%= lbltotqty.ClientID %>').innerText = totalQuantity.toFixed(2);

        }
    </script>
       <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" PopupButtonID="txtDate"
                TargetControlID="txtDate">
            </cc1:CalendarExtender>

</asp:Content>
