<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Admin_Change_Password.aspx.cs" Inherits="Admin_Admin_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-heading">
        <h1>
            Change Password</h1>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <h4>
                            Change Password</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    Old Password :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textoldpass"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="r"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="Textoldpass" class="form-control" placeholder="Enter Old Password"
                                    runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    New Password :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtloginpass"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="r"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtloginpass" class="form-control" placeholder="Enter New Password"
                                    runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-sm-12">
                                <label for="disabledinput">
                                    Confirm Password :
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cnf_pass_txt"
                                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="r"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtloginpass" SetFocusOnError="true"
                                        Display="Dynamic" ControlToValidate="cnf_pass_txt" ErrorMessage="New password has not been matched"  ValidationGroup="r"></asp:CompareValidator>
                                </label>
                                <asp:TextBox ID="cnf_pass_txt" class="form-control" placeholder="Enter New Password"
                                    runat="server" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-sm-12" style="text-align: right">
                                <div class="btn-toolbar">
                                    <asp:Button ID="BtnAdd" runat="server" class="btn-primary btn" Text="Change Passward" OnClick="BtnAdd_Click"
                                        ValidationGroup="r" />
                                    <asp:Button ID="BtnCancle" runat="server" class="btn-primary btn" Text="Cancel" OnClick="BtnCancle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
    <asp:Label ID="LblCenterId" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbluserid" runat="server" Visible="false"></asp:Label>
</asp:Content>
