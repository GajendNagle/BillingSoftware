<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Admin_Home.aspx.cs" Inherits="Admin_Admin_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-midnightblue">
                    <div class="panel-heading">
                        <div class="col-sm-6">
                            <h4 style="color: white">
                                Admin Home</h4>
                        </div>
                        <div class="col-sm-2" style="text-align: right">
                        </div>
                        <div class="col-sm-4" style="padding-top: 3px">
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2 col-xs-6 col-sm-3">
                                <a class="btn btn-primary" href="Delivery_Challan.aspx">Delivery Challan</a></div>
                            <div class="col-md-2 col-xs-6 col-sm-3">
                                <a class="btn btn-primary" href="Estimate_Bill.aspx">Estimate Bill</a>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-sm-12" style="text-align: right">
                                <div class="btn-toolbar">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="LblDate" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lbluserid" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblcenterid" runat="server" Visible="false"></asp:Label>
</asp:Content>
