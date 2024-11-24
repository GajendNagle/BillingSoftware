<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="PrintInvoiceReceipt.aspx.cs" Inherits="Admin_PrintInvoiceReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divPrint" style="margin: 2rem;">
        <table style="border: 1px solid #000; background-color: #fff; height: auto; width: 62%; margin: 20px auto; font-family: Arial, sans-serif; border-collapse: collapse;">
            <tr>
                <td colspan="3" style="text-align: center; font-size: 15px;">
                    <h4 class="text-capitalize" style="text-decoration: underline; display: inline;">Estimate bill</h4>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-size: 24px;">
                    <b>
                        <asp:Label runat="server" ID="lblCompanyName"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-size: 16px;">
                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center; font-size: 18px;">Phone: 
                   
                    <asp:Label runat="server" Style="font-size: 16px;" ID="lblCompanyMobile"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding: 10px; width: 65%; border: 1px solid #000; vertical-align: top; text-align: left;">
                    <strong>Name:</strong>
                    <asp:Label ID="lblCustomerName" runat="server" Style="font-size: 16px;"></asp:Label><br />
                    <strong>Mobile:</strong>
                    <asp:Label ID="lblMobileNumber" runat="server" Style="font-size: 16px;"></asp:Label><br />
                    <strong>Address:</strong>
                    <asp:Label ID="lblCustAddress" runat="server" Style="font-size: 16px;"></asp:Label>
                </td>
                <td style="padding: 10px; width: 35%; border-top: 1px solid; border-bottom: 1px solid #000; vertical-align: top; text-align: left;">
                    <strong>DC No:</strong>
                    <asp:Label ID="lblOrderNo" runat="server" Style="font-size: 16px;"></asp:Label><br />
                    <strong>Date:</strong>
                    <asp:Label ID="lblOrderDate" runat="server" Style="font-size: 16px;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:DataList ID="grdPrint" runat="server" RepeatDirection="Vertical" Style="width: 100%;">
                        <HeaderTemplate>
                            <tr>
                                <th style="border-right: 1px solid black; padding: 8px; text-align: left;">Sr No</th>
                                <th style="border-left: 1px solid black; padding: 8px; text-align: left;">Particulars</th>
                                <th style="border-left: 1px solid black; padding: 8px; text-align: left;">Qty</th>
                                <th style="border-left: 1px solid black; padding: 8px; text-align: left;">Rate</th>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="border-bottom: 1px solid black; border-top: 1px solid black; padding: 8px; text-align: left;">
                                    <asp:Label ID="lblSrNo" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                </td>
                                <td style="border: 1px solid black; padding: 8px; text-align: left;">
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Product_Name") %>'></asp:Label>
                                </td>
                                <td style="border: 1px solid black; padding: 8px; text-align: left;">
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Product_Qty") %>'></asp:Label>
                                </td>
                                <td style="border-bottom: 1px solid black; border-top: 1px solid black; padding: 8px; text-align: left;">
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Product_Rate") %>'></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; font-size: 13px; font-weight: bold; padding: 2px 0 0 2px">Total Qty: 
         <asp:Label ID="lbltotalAmount" runat="server" Text="0.00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; font-size: 14px; padding: 38px 0 0 2px">
                    <strong>Receiver Signature</strong>
                </td>
                <td style="text-align: left;">
                    <img src="../images/signature.jpg" width="100" style="margin-left: 9rem;" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right; font-size: 13px; padding: 5px">
                    <strong>For: WOOD CRUST PLYWOOD</strong>
                </td>
            </tr>
        </table>
    </div>

    <div class="footer" style="margin-top: 20px; text-align: center;">
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Print" OnClientClick="CallPrint('divPrint'); return false;" />
    </div>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', 'PrintWindow', 'left=0,top=0,width=800,height=600,toolbar=1,scrollbars=1,status=1');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
        }
    </script>

</asp:Content>







