<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

   <div class="container" style="max-height:200px;"> 
    <form id="form1" runat="server" role="form">
        <div class="alert alert-success alert-dismissable">
            <asp:Label runat="server" id="msg"></asp:Label>
        </div>
        
    <div class="row">
        <div class="form-group col-lg-2">
            <asp:Label ID="id" runat="server" Text="ID"></asp:Label>
            <asp:TextBox runat="server" ID="id1" CssClass="form-control"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="vId" runat="server" ControlToValidate="lastN" ValidationGroup="save" ErrorMessage="Enter Id" Display="Dynamic" ForeColor="Red"/>
             <asp:RangeValidator runat="server" ID="RangeValidator1" Type="Integer" MinimumValue="1" MaximumValue="99" ControlToValidate="id1" ErrorMessage="ID should be greater than 0 and less than 100" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
        </div>
    </div>

     <div class="row">
         <div class="form-group col-lg-2">
            <asp:Label ID="lblF" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox runat="server" ID="firstN" CssClass="form-control"> </asp:TextBox>
             <asp:RequiredFieldValidator ID="vFirstN" runat="server" ControlToValidate="firstN" ValidationGroup="save" ErrorMessage="Enter first name" Display="Dynamic" ForeColor="Red"/>
             <asp:RegularExpressionValidator ID="vFirstN2" runat="server" ControlToValidate="firstN" ErrorMessage="last Name must be string without special characters" Display="Dynamic" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="save" ForeColor="Red"/>
        </div>
    </div>

     <div class="row">
         <div class="form-group col-lg-2">
            <asp:Label ID="lblL" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox runat="server" ID="lastN" CssClass="form-control"> </asp:TextBox>
             <asp:RequiredFieldValidator ID="vLastN" runat="server" ControlToValidate="lastN" ValidationGroup="save" ErrorMessage="Enter Last name" Display="Dynamic" ForeColor="Red"/>
             <asp:RegularExpressionValidator ID="vLastN2" runat="server" ControlToValidate="lastN" ErrorMessage="last Name must be string without special characters" Display="Dynamic" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="save" ForeColor="Red"/>
        </div>
    </div>

     <div class="row">      
         <div class="form-group col-lg-2">
            <asp:Label ID="lblage" runat="server" Text="age"></asp:Label>
            <asp:TextBox runat="server" ID="age" CssClass="form-control"> </asp:TextBox>
              <asp:RequiredFieldValidator ID="vAge" runat="server" ControlToValidate="age" ValidationGroup="save" ErrorMessage="Enter age" ForeColor="Red" Display="Dynamic"/>
             <asp:RangeValidator runat="server" ID="vAge2" Type="Integer" MinimumValue="1" MaximumValue="99" ControlToValidate="age" Display="Dynamic" ErrorMessage="age should be greater than 0 and less than 100" ForeColor="Red"></asp:RangeValidator>
        </div>
    </div>

    <div class="row">
         <div class="form-group col-lg-2">
            <asp:Label ID="lblSex" runat="server" Text="sex"></asp:Label>
            <asp:TextBox  runat="server" ID="sex" CssClass="form-control"> </asp:TextBox>
             <asp:RequiredFieldValidator ID="vSex" runat="server" ControlToValidate="sex" ValidationGroup="save" ErrorMessage="Enter sex" Display="Dynamic" ForeColor="Red" />
             <asp:RegularExpressionValidator ID="vSex2" runat="server" ControlToValidate="sex" ErrorMessage="Sex must be represented with only one character (F or M)" Display="Dynamic" ValidationExpression="^[a-zA-Z'.\s]{1,1}$" ValidationGroup="save" ForeColor="Red"/>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-lg-2">
            <asp:Label ID="lblMobile" runat="server" Text="Mobile"></asp:Label>
            <asp:TextBox  runat="server" ID="mobile" CssClass="form-control"> </asp:TextBox>
            <asp:RegularExpressionValidator ID="vMobi" runat="server" ControlToValidate="mobile" ErrorMessage="mobile number should be 10 digits" ValidationExpression="[0-9]{10}" Display="Dynamic" ValidationGroup="save" ForeColor="Red"/>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-lg-2">
            <asp:Label ID="lblactive" runat="server" Text="active"></asp:Label>
            <asp:TextBox  runat="server" ID="active" CssClass="form-control"> </asp:TextBox>
            <asp:RequiredFieldValidator ID="vActive" runat="server" ControlToValidate="active" ValidationGroup="save" ErrorMessage="Enter active" Display="Dynamic" ForeColor="Red"/>
            <asp:RegularExpressionValidator ID="vActive2" runat="server" ControlToValidate="active" ErrorMessage="active must be string without special character, and it should be more than 2 characters and not greater than 6" Display="Dynamic" ValidationExpression="^[a-zA-Z'.\s]{3,6}$" ValidationGroup="save" ForeColor="Red"/>
        </div>
    </div>
        
        <asp:Button  runat="server" ID="import" Text="Next import" OnClick="import_click" CssClass="btn btn-primary" />
        <asp:Button  runat="server" ID="save" Text="Save to Database" OnClick="save_click" ValidationGroup="save" CssClass="btn btn-success" />
        <asp:Button  runat="server" ID="delete" Text="delete" OnClick="delete_click" CssClass="btn alert-danger"/>
        <asp:Button  runat="server" ID="view" Text="view from Database" OnClick="view_click" CssClass="btn btn-default" />
        <asp:Button  runat="server" ID="clear" Text="clear" OnClick="clear_click" CssClass=" btn btn-warning"/>
        <asp:Button  runat="server" ID="Infor" Text="InFor" OnClick="inFor_click" CssClass=" btn btn-primary"/>


    </form>
  </div>
</body>

<script type="text/javascript">    

   

</script>


</html>
