<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Shop.Login" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div align="center" class="container jumbotron bg-light boxshadow" style="width:35%">
            <form>
                <div class="text-black-50">
                    <h2>Login</h2>
                </div>
                <div class="form-group">
                    <label class="text-dark">Email Address</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_email" runat="server" width="80%" CssClass="form-control"  placeholder="example@gmail.com"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid email" ControlToValidate="tb_email"  Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Password</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_pass" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control" width="80%"></asp:TextBox>
                </div>
                <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btn_login_Click" />
                <div>   
                    <asp:LinkButton ID="lk_newUser" runat="server" CssClass="btn btn-link" OnClick="lk_newUser_Click">New User?</asp:LinkButton>
                </div>
                <div class="form-group">
                    <asp:Label ID="lbl_log_error" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </form>
        </div>

    </asp:Content>