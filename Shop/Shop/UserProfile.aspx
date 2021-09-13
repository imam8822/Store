<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserProfile.aspx.cs" Inherits="Shop.UserProfile" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container jumbotron bg-light boxshadow" align="center" style="width:35%">
            <form>
            <div class="text-black-50">
                <h2>Your Profile</h2>
            </div>
                <div class="form-group">
                    <label class="text-dark">First Name</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_fname" runat="server" CssClass="form-control" width="80%" placeholder="eg. Rahul"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="register" ControlToValidate="tb_fname" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Last Name</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_lname" runat="server" CssClass="form-control" width="80%" placeholder="eg.Kumar"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="register" ControlToValidate="tb_lname" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Date of Birth</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_dob" class="form-control" placeholder="dd/mm/yyyy" width="80%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="tb_dob" ValidationGroup="register" runat="server" ForeColor="Red" ErrorMessage="This field cannot be empty." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label class="text-dark">Email Address</label><span class="mandatory">*</span>
                    <asp:TextBox ID="tb_email" runat="server" width="80%" CssClass="form-control" placeholder="example@gmail.com" ReadOnly="True"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid email" ControlToValidate="tb_email"  Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="tb_email" ValidationGroup="register" runat="server" ErrorMessage="This feild cannot be empty." ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:Label ID="lbl_error_email" runat="server" Text="" ForeColor="red"></asp:Label>
                </div>
                <div class="form-group">
                   <label class="text-dark">Enter Password</label><span class="mandatory">*</span>
                   <asp:TextBox ID="tb_pass" class="form-control" width="80%" placeholder="Password" TextMode="Password" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="register" ControlToValidate="tb_pass"  ForeColor="Red" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btn_update" runat="server" Text="Update" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="register" Onclick="btn_update_Click" />    
                <div class="formgroup">
                    <br/>
                    <asp:Label ID="lbl_password" runat="server" ForeColor="Red" Text=""></asp:Label>
                </div>
                
            </form>

        </div>

</asp:Content>