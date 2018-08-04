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
         <%-- use the smart tag to select a data source, pick the ODS we just setup, pick the two values we need for the dropdown
            
            - we need to add a parameter called AppendDataBoundItems="true"

            - we also need to add the "select..." part of the dropdown, use the smart tag again, edit items, add item, name = select... and value = 0

            --%>
        <asp:DropDownList ID="CategoryList"
            runat="server"
            AppendDataBoundItems="true"
            DataSourceID="CategoryListODS"
            DataTextField="CategoryName"
            DataValueField="CategoryID">
            <asp:ListItem Value="0">Select...</asp:ListItem>
        </asp:DropDownList>
       
        &nbsp;&nbsp;
        <asp:LinkButton ID="FetchCategoryProducts" runat="server" OnClick="FetchCategoryProducts_Click">Fetch</asp:LinkButton>
        <br />
    </div>
    
    <%-- use the smart tag to configure the ODS for the grid view
        
        - when you select a data source, it will automatically create fields for all table rows

        - datafield is removed after converting to template

        - headertext is just the field name, we can customize this for more readable UI

        - sortexpression is used for sorting of columns

        - use gridview, smart tag, edit columns, select each column one at a time, convery this field into a TemplateField

        - now we ahve edit and item template: item is read only, edit is not read only
            - for now we DO NOT need the edit itemtemplate, just delete it
            
        - item template is a read only field, the qustion is how does it know what data it is supposed to display?
            - within the Bind() is 

        - bind() is a two way trip
        - eval() is one way trip (read only)

        - on labels we can use either one of these, it doesn't matter because we can't change labels
        - on a text box we NEED to use bind()
        - for labels  best practice is to use eval()

        - don't forget to enable paging
        
        --%>

    <%-- HOMEWORK IS ADD A SECOND PARAMETER TO SEARCH, A TEXTBOX FOR PARTIAL PRODUCT NAME
        
        - THEN GO AND RECONFIGURE THE PRODUCT LIST ODS SO THAT IT USES THE GETBYCATEGORIESANDNAME METHOD
        
        
        --%>

    <div class="row">
        <asp:GridView ID="ProductList" runat="server" AutoGenerateColumns="False" DataSourceID="ProductListODS" PageSize="5" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="ProductID">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("ProductID") %>' ID="Label1"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">                    
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Bind("ProductName") %>' ID="Label2"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier" SortExpression="SupplierID">                    
                    <ItemTemplate>

                        <%--<asp:Label runat="server" Text='<%# Bind("SupplierID") %>' ID="Label3"></asp:Label>--%>

                        <%-- drag a dropdown list from the toolbox, configure it to use a method to populate 
                            
                            - we need to add a property called selectedvalue, and put '<%# Bind("SupplierID") %>' there

                            - you need to use single quotes '' for this c# stuff

                            - you can add a parameter enabled = false to stop the user from screwing around with the values in the dropdown list

                            --%>

                        <asp:DropDownList ID="SupplierIDList" runat="server" DataSourceID="SupplierListODS" DataTextField="CompanyName" 
                            DataValueField="SupplierID" selectedvalue='<%# Bind("SupplierID") %>' Enabled="false"></asp:DropDownList>
                        
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryID">                    
                    <ItemTemplate>
                        <%--<asp:Label runat="server" Text='<%# Bind("CategoryID") %>' ID="Label4"></asp:Label>--%>

                        <asp:DropDownList ID="CategoryIDList" runat="server" DataSourceID="CategoryListODS" DataTextField="CategoryName" 
                            DataValueField="CategoryID" selectedvalue='<%# Bind("CategoryID") %>' Enabled="false"></asp:DropDownList>


                    </ItemTemplate>
                </asp:TemplateField>
                <%-- the amount of decimal places on the currency is wrong, fix it with string formatter 
                    
                    - note that you can use c# code within the <% %> tags

                    - we can't use bind with a formatter so we have to change to eval

                    --%>
                <asp:TemplateField HeaderText="Unit Price" SortExpression="UnitPrice">                    
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# string.Format("{0:0.00}", Eval("UnitPrice")) %>' ID="Label5"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disc" SortExpression="Discontinued">                    
                    <ItemTemplate>
                        <asp:CheckBox runat="server" Checked='<%# Bind("Discontinued") %>' Enabled="false" ID="CheckBox1"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
   
    <%-- EntityDataSource, ObjectDataSource, SqlDataSource (DO NOT USE SQL DATASOURCE) available 
        - we are responsible for some minor security using the BLL, so bypassing the BLL using SqlDataSource is stupid

        - best practice is to use object data source... Don likes to put them all at the bottom of the Content "section"

        - name it something related to the major control that will be using it

        - use the smart tag, "configure data source" to get to a wizard we use to configure the data source (checkbox only show data components)
        
        - if you can't find what you want in your wizard, you probably forgot to rebuild your solution

        - select your controller, click next, pick the method you want to add from the dropdown list, click finish (might have to click next?)

        - once the ODS is setup, we have to set it up on the control itself

        - this ods replaces the "code behind", the only thing missing by default is the prompt line

        --%>


    <asp:ObjectDataSource ID="CategoryListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Categories_List" TypeName="NorthwindSystem.BLL.CategoryController"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SupplierListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Suppliers_List" TypeName="NorthwindSystem.BLL.SupplierController"></asp:ObjectDataSource>


    <%-- all parameters expected will be listed when you click next
        
        - you can't just click finish if it's expecting an arguement

        - you'll need to set the parameter source, aka which control on the page is giving this value.

        - make sure to set a default value to zero
        
        --%>

    <asp:ObjectDataSource ID="ProductListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Products_GetByCategories" TypeName="NorthwindSystem.BLL.ProductController">
        <SelectParameters>
            <asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" DefaultValue="0" Name="categoryid" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>


    <%--<asp:ObjectDataSource ID="ProductListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Products_GetByCategoryAndName" TypeName="NorthwindSystem.BLL.ProductController">
        <SelectParameters>
            <asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" DefaultValue="0" Name="category" Type="Int32"></asp:ControlParameter>
            <asp:Parameter Name="partialname" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>--%>

    <%-- when using ODS you still need code behind to handle errors and for  buttons to make sure the user actually selected something

        - 
        
        
        --%>

</asp:Content>
