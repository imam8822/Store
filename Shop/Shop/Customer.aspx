<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Customer.aspx.cs" Inherits="Shop.Customer1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
        <div class="container jumbotron bg-light boxshadow" align="center" style="width:35%">
            <form>
            <div class="text-black-50">
                <h2>Sign Up</h2>
            </div>
                <div class="form-group">
                    <label class="text-dark">First Name</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_fname" runat="server" CssClass="form-control" width="80%" placeholder="eg. Rahul"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tb_fname" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Last Name</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_lname" runat="server" CssClass="form-control" width="80%" placeholder="eg.Kumar"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tb_lname" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Date of Birth</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_dob" class="form-control" placeholder="dd/mm/yyyy" width="80%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="tb_dob" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Email Address</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_email" runat="server" width="80%" CssClass="form-control" placeholder="example@gmail.com"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid email" ControlToValidate="tb_email"  Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="tb_email" runat="server" ErrorMessage="This feild cannot be empty." ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                   <label class="text-dark">Password</label><span class="mandatory">*</span>
                   <asp:TextBox ID="tb_password" class="form-control" width="80%" placeholder="Password" TextMode="Password" runat="server" ></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tb_password" ForeColor="Red" ErrorMessage="Password should contain 8 character - one uppercase, one lowercase, one numeric value and a special character." Display="Dynamic" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"></asp:RegularExpressionValidator>         
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_password"  ForeColor="Red" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                       <label class="text-dark">Confirm Password</label><span class="mandatory">*</span>
                       <asp:TextBox ID="tb_confirm" class="form-control" width="80%" placeholder="Confirm Password" runat="server" TextMode="Password"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_confirm"  ForeColor="Red" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator><br />
                       <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tb_confirm" ControlToCompare="tb_password" ForeColor="Red" ErrorMessage="Password Dosen't match "></asp:CompareValidator>
                </div>
                 <asp:Button ID="btn_login" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btn_login_Click" />         
            </form>
                 <asp:LinkButton ID="lb1" runat="server"  CssClass="btn btn-link" OnClick="lb1_Click">Already Registered</asp:LinkButton>

        </div>

</asp:Content>