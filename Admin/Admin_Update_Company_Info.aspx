<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Admin_Update_Company_Info.aspx.cs" Inherits="Admin_Admin_Update_Company_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-heading">
        <h1>Store Info</h1>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>Store Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    Store Name :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcompany"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtcompany" runat="server" class="is_required validate account_input form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    Address :
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaddress"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                </label>

                                <asp:TextBox ID="txtaddress" runat="server" class="is_required validate account_input form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    Firm Name
                                </label>
                                <asp:TextBox ID="txtcentername" class="form-control" placeholder="Enter Center Name"
                                    runat="server" autocomplete="off" onFocus="this.select()" required="required"></asp:TextBox>
                            </div> 
                        <div class="col-sm-12">
                            <label for="disabledinput">
                                Phone No. :<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ControlToValidate="txtphone" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtphone" runat="server" class="is_required validate account_input form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-12">
                            <label for="disabledinput">
                                Eamil :
                            </label>
                            <asp:TextBox ID="txtemail" runat="server" class="is_required validate account_input form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-12">
                            <label for="disabledinput">
                                G.S.Tin No. :
                            </label>
                            <asp:TextBox ID="txttinno" runat="server" class="is_required validate account_input form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-12">
                            <label for="disabledinput">
                                Store Logo :
                            </label>
                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                        </div>
                        <div class="col-sm-12">
                            <label for="disabledinput">
                                Bill Print Size :
                            </label>

                            <asp:DropDownList ID="ddlprintmode" runat="server" class="form-control">
                                <asp:ListItem>Thermal</asp:ListItem>
                                <asp:ListItem>A5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                            </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="btn-toolbar" style="text-align: right">
                                <asp:Button ID="btnlogin" runat="server" CausesValidation="False" OnClick="btnlogin_Click"
                                    Text="Update (Alt+U)" AccessKey="u" class="btn-primary btn" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>Store Logo</h4>
                    </div>
                    <div class="panel-body">
                        <div class="col-md-12">
                            <asp:Image ID="Image1" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
</asp:Content>
