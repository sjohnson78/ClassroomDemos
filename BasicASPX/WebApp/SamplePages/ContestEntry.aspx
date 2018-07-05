<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestEntry.aspx.cs" Inherits="WebApp.SamplePages.ContestEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="page-header">
        <h1>Contest Entry</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-style: italic">
                This illustrates some simple controls to fill out an entry form for a contest. 
                This form will use basic bootstrap formatting and illustrate Validation.
            </blockquote>
            <p>
                Please fill out the following form to enter the contest. This contest is only available to residents in Western Canada.
            </p>

        </div>
    </div>

    <%-- validation, we just grab from the toolbox --%>
    <%-- required field validator --%>

    <%-- if ANY control has runat="server", ALL controls MUST have runat="server" --%>
    
    <%-- best practice is to rename the id right away to include the field it relates to --%>
    <%-- what does runat="server" do exactly?? --%>
    <%-- ErrorMessage: text displayed in validation summary --%>
    <%-- ControlToValidate: which control is this required field validator for? --%>
    <%-- SetFocusOnError: places cursor on the field that has an error, in the case of multiple the cursor goes to the first one --%>
    <%-- ForeColor: changes styling color of error msg --%>
    <%-- dynamic display makes the error msg look a lot better (pushes it close), setting it to none makes it so it doesn't display next to the field --%>
    <%-- text is a "secondary" error message that displays next to the field, if blank it will just disply ErrorMessage  --%>        

    <asp:RequiredFieldValidator ID="RequiredFieldFirstName" 
        runat="server" 
        ErrorMessage="First name is required." 
        ControlToValidate="FirstName" 
        SetFocusOnError="true" 
        ForeColor="Firebrick" 
        Display="None"        
        ></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldLastName" 
        runat="server" 
        ErrorMessage="Last name is required." 
        ControlToValidate="LastName" 
        SetFocusOnError="true" 
        ForeColor="FireBrick" 
        Display="None"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldAddress1" 
        runat="server" 
        ErrorMessage="Address is required." 
        ControlToValidate="StreetAddress1" 
        SetFocusOnError="true" 
        ForeColor="FireBrick" 
        Display="None"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldCity" 
        runat="server" 
        ErrorMessage="City is required." 
        ControlToValidate="City" 
        SetFocusOnError="true" 
        ForeColor="FireBrick" 
        Display="None"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredFieldPostalCode" 
        runat="server" 
        ErrorMessage="Postal Code is required." 
        ControlToValidate="PostalCode" 
        SetFocusOnError="true" 
        ForeColor="FireBrick" 
        Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionPostalCode" 
        runat="server" 
        ErrorMessage="Invalid postal code (sample T6T6T6)" 
        ControlToValidate="PostalCode" 
        SetFocusOnError="true" 
        ForeColor="Firebrick" 
        Display="None" 
        ValidationExpression="[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]"
        ></asp:RegularExpressionValidator>


    <asp:RequiredFieldValidator ID="RequiredFieldEmailAddress" 
        runat="server" 
        ErrorMessage="Email Address is required." 
        ControlToValidate="LastName" 
        SetFocusOnError="true" 
        ForeColor="FireBrick" 
        Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionEmailAddress" 
        runat="server" 
        ErrorMessage="Invalid email address (sample T6T6T6)" 
        ControlToValidate="EmailAddress" 
        SetFocusOnError="true" 
        ForeColor="Firebrick" 
        Display="None" 
        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
        ></asp:RegularExpressionValidator>
    <%-- get this email validation expression from emailregex.com --%>
    
    

    <%-- validation summary from toolbox is used to display the errors/messages --%>
    <%--HeaderText is a msg for the user--%>

    <div class="row">
        <asp:ValidationSummary ID="ValidationSummary1" 
        runat="server" 
        HeaderText="Correct the following concerns and resubmit" 
        CssClass="alert alert-danger"/> 
    </div>
    

    <div class="grid-form">
        <h3>Contest Entry</h3>
        <asp:Label ID="Label1" runat="server" Text="First Name"
                AssociatedControlID="FirstName"></asp:Label>
        <asp:TextBox ID="FirstName" runat="server" 
            ToolTip="Enter your first name." MaxLength="25"></asp:TextBox> 
                  
        <asp:Label ID="Label2" runat="server" Text="Last Name"
            AssociatedControlID="LastName"></asp:Label>
        <asp:TextBox ID="LastName" runat="server" 
            ToolTip="Enter your last name." MaxLength="25"></asp:TextBox> 
                        
        <asp:Label ID="Label3" runat="server" Text="Street Address 1"
                AssociatedControlID="StreetAddress1"></asp:Label>
        <asp:TextBox ID="StreetAddress1" runat="server" 
            ToolTip="Enter your street address." MaxLength="75"></asp:TextBox> 
                  
        <asp:Label ID="Label4" runat="server" Text="Street Address 2"
            AssociatedControlID="StreetAddress2"></asp:Label>
        <asp:TextBox ID="StreetAddress2" runat="server" 
            ToolTip="Enter your additional street address." MaxLength="75"></asp:TextBox> 

        <asp:Label ID="Label5" runat="server" Text="City"
            AssociatedControlID="City"></asp:Label>
        <asp:TextBox ID="City" runat="server" 
            ToolTip="Enter your City name" MaxLength="50"></asp:TextBox> 
                  
        <asp:Label ID="Label6" runat="server" Text="Province"
            AssociatedControlID="Province"></asp:Label>
        <asp:DropDownList ID="Province" runat="server" width="75px">
            <asp:ListItem Value="AB" Text="AB"></asp:ListItem>
            <asp:ListItem Value="BC" Text="BC"></asp:ListItem>
            <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
            <asp:ListItem Value="SK" Text="SK"></asp:ListItem>
        </asp:DropDownList>
                  
        <asp:Label ID="Label7" runat="server" Text="Postal Code"
                AssociatedControlID="PostalCode"></asp:Label>
        <asp:TextBox ID="PostalCode" runat="server" 
            ToolTip="Enter your postal code"  MaxLength="6"></asp:TextBox> 
                 
        <asp:Label ID="Label8" runat="server" Text="Email"
                AssociatedControlID="EmailAddress"></asp:Label>
        <asp:TextBox ID="EmailAddress" runat="server" 
            ToolTip="Enter your email address"
                TextMode="Email"></asp:TextBox> 

        <asp:Label ID="Label9" runat="server" Text="Agree to Terms"
            AssociatedControlID="Terms"></asp:Label>
        <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of the contest" />
   
        <p>Note: You must agree to the contest terms in order to be entered.</p> 
    
        <p>
            Enter your answer to the following calculation instructions:<br />
            Multiply 15 times 6<br />
            Add 240<br />
            Divide by 11<br />
            Subtract 15<br />
            <asp:TextBox ID="CheckAnswer" runat="server" ></asp:TextBox>
        </p>
        <p>
            <%-- remember that you double click one of these buttons in the design mode to add the onclick part here, and also add a
                method to thispage.aspx.cs that you can add code to--%>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"  />&nbsp;&nbsp;
            <%-- we need to set the causesvalidation property to false on a clear button, since we don't care about the values inputted, and this property is set to true for default--%>
            <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click"  />
        </p>
               
        <asp:Label ID="Message" runat="server" Text="bob" ></asp:Label>

        
    </div>  
    
</asp:Content>
