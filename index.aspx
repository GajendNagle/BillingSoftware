<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DV Infosoft Pvt. Ltd.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="assets/css/styles.minc726.css?=140">
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600' rel='stylesheet'
        type='text/css'>
</head>
<body class="focusedform deep" style=" background: url(Logo/1.jpg) left top repeat">
    <form id="form1" runat="server">
    <div class="verticalcenter">
       <%-- <a href="index.aspx">
            <img src="assets/img/dvlogo.png" alt="Logo" class="brand" /></a>--%>
        <div class="panel panel-primary" style="padding-top:130px">
            <div class="panel-body deep1">
                <h4 class="text-center" style="margin-bottom: 25px">
                    Log in to get started
                </h4>
                <div action="#" class="form-horizontal" style="margin-bottom: 0px !important; ">
                    <div class="form-group">
                        <div class="col-sm-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                <asp:TextBox ID="txtloginname" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-12">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <asp:TextBox ID="txtloginpass" class="form-control" placeholder="Password" TextMode="password"
                                    runat="server" onkeypress="txtloginpass_KeyPress"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer  deep1">
                <div class="pull-right">
                    <asp:Button ID="btnlogin" runat="server" Text="Log In" class="btn btn-primary" OnClick="btnlogin_Click" />

                </div>
            </div>
            <%-- <div class="panel-footer  deep1">
                  Sponsored By - Geetanjali Mobile & Electronics
                 </div>--%>
        </div>
    </div>
    </form>
</body>
</html>
