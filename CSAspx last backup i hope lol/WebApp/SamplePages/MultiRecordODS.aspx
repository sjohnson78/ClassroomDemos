<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordODS.aspx.cs" Inherits="WebApp.SamplePages.MultiRecordODS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="page-header">
        <h1>Product MultiRecord Object DataSource</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-warning">
            <blockquote style="font-style: italic">
                This illustrates a display of multiple records from a query.
                The parameter will be submitted from either a drop down list
                or a textbox. The resulting dataset is of the enity Product.
                The output will be displayed in a customer GridView.
            </blockquote>
        </div>
    </div>
      <div class="row">
        <asp:DataList ID="Message" runat="server">
          <ItemTemplate>
               <%# Container.DataItem %>
          </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="row">
        <asp:Literal ID="Literal1" runat="server" Text="Categories:"></asp:Literal>
        &nbsp;&nbsp;
        <asp:DropDownList ID="CategoryList" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:LinkButton ID="FetchCategoryProducts" runat="server" OnClick="FetchCategoryProducts_Click">Fetch</asp:LinkButton>
        <br />
    </div>
    
    <div class="row">
        <asp:GridView ID="ProductList" runat="server">
        </asp:GridView>
     
    </div>
   
</asp:Content>
