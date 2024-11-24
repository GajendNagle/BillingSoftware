<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Update_DeliveryChallan.aspx.cs" Inherits="Admin_Update_DeliveryChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .grid-header {
            background-color: #34495e;
            color: White;
            text-align: center;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>Bill Information</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtDate">
                                            Date:</label>
                                        <asp:TextBox ID="txtdate" AutoComplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtCustomerName">
                                            Customer Name:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtCustomerName"></asp:TextBox>
                                        <asp:RegularExpressionValidator ValidationGroup="ValidationGA" ID="RegularExpressionValidator1"
                                            runat="server" Display="Dynamic" ErrorMessage="Customer Name Incorrect Format"
                                            ForeColor="Red" ControlToValidate="txtCustomerName" ValidationExpression="^[A-Za-z ]{1,}$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValidationGA"
                                            runat="server" ControlToValidate="txtCustomerName" Display="Dynamic" ErrorMessage="Customer Name is Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtMobileNumber">
                                            Mobile Number:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" MaxLength="10"
                                            ID="txtMobileNumber"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValidationGA"
                                            runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ErrorMessage="Mobile Number is Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtAddress">
                                            Address:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtAddress"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="ValidationGA" ControlToValidate="txtAddress"
                                            Display="Dynamic" ErrorMessage="Address is Required"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ValidationGroup="ValidationGA" runat="server" Display="Dynamic"
                                            ErrorMessage="Address format Incorrect" ForeColor="Red" ControlToValidate="txtAddress"
                                            ValidationExpression="^[A-Za-z0-9,-. ]{1,100}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtItemName">
                                            Item Name:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtItemName">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="ValidationGA"
                                            runat="server" ControlToValidate="txtItemName" Display="Dynamic" ErrorMessage="Item Name is Required"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtQuantity">
                                            Item Qty:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtQuantity"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="ValidationGA"
                                            Display="Dynamic" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please enter a valid quantity."
                                            ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ValidationGA"
                                            runat="server" ControlToValidate="txtQuantity" Display="Dynamic" ErrorMessage="Item Qty is Required">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-3 mb-3">
                                    <div class="form-group">
                                        <label for="txtRate">
                                            Rate:</label>
                                        <asp:TextBox runat="Server" AutoComplete="off" class="form-control" ID="txtRate"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationGroup="ValidationGA"
                                            Display="Dynamic" runat="server" ControlToValidate="txtRate" ErrorMessage="Please enter a valid rate."
                                            ValidationExpression="^\d+(\.\d+)?$" ForeColor="Red">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="ValidationGA"
                                            runat="server" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="Rate is Required">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            <div class="col-sm-3">
                                <div class="btn-toolbar" style="margin-top: 3rem;">
                                    <asp:Button runat="server" Text="Add Item" ValidationGroup="ValidationGA" ID="btnAdd" class="btn btn-outline-success" OnClick="btnAdd_onClick" />
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
                        <h4>Bill Information Report</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Panel ID="pnlReceiptData" runat="server">
                                    <asp:GridView runat="server" CssClass="table table-bordered text-center" AutoGenerateColumns="false"
                                        ID="grdReportData" OnRowCommand="grdReportData_OnRowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. No." ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="grid-SrNo" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct_Name" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Qty" ItemStyle-CssClass="grid-Qty" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct_Qty" runat="server" Text='<%# Eval("Product_Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Rate" ItemStyle-CssClass="grid-Qty" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProduct_Rate" runat="server" Text='<%# Eval("Product_Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="grid-TotalAmt" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="grid-TotalAmt" HeaderStyle-CssClass="grid-header">
                                                <ItemTemplate>
                                                    <asp:LinkButton Text="Delete" CommandName="DeleteRecord" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>


                                    <div class="col-sm-12" style="text-align: right; margin-top: 2rem;">
                                        <asp:Button runat="server" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_onClick"
                                            CssClass="btn btn-primary" Visible="false" />
                                    </div>
                                    <div runat="server" id="Totaltbl" visible="false">
                                        <asp:Label ID="lbltotqty" runat="server" Text="0"></asp:Label>
                                        <asp:Label ID="lbltotalamt" runat="server" Text="0"></asp:Label>
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
        function validateNumericInput(event) {
            const char = String.fromCharCode(event.which);
            if (!/^[0-9.]*$/.test(char)) {
                event.preventDefault();
            }
        }

        document.querySelectorAll('[id$=lblQty], [id$=lblRate]').forEach(input => {
            input.addEventListener('keypress', validateNumericInput);
        });

        document.getElementById('<%= txtMobileNumber.ClientID %>').addEventListener('input', function (event) {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
        document.getElementById('<%= txtRate.ClientID %>').addEventListener('input', function (event) {
            this.value = this.value.replace(/[^0-9.]/g, '');
        });
        document.getElementById('<%= txtQuantity.ClientID %>').addEventListener('input', function (event) {
            this.value = this.value.replace(/[^0-9.]/g, '');
        });

        document.getElementById('<%= txtCustomerName.ClientID %>').addEventListener('input', function (event) {
            this.value = this.value.replace(/[^A-Za-z ]/g, '');
        });

        document.querySelector('form').addEventListener('submit', function (event) {
            let isValid = true;

            const mobileNumber = document.getElementById('<%= txtMobileNumber.ClientID %>').value;
            if (mobileNumber.length !== 10 || isNaN(mobileNumber)) {
                isValid = false;
            }

            const customerName = document.getElementById('<%= txtCustomerName.ClientID %>').value;
            if (!customerName.match(/^[A-Za-z ]+$/)) {
                isValid = false;
            }

            if (!isValid) {
                event.preventDefault();
            }
        });
    </script>
</asp:Content>
