<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="Vehicle-Rent.aspx.cs" Inherits="km_Auto_Rental.Vehicle_Rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">





<section style="background-image: url('Images/Contact-blue.jpg');"> 
    <div id="hometop">
     <div class="container text-center">
        <div class="row align-items-end">
            <div class="col">
        
        </div>
       </div>
         </div>
        </div>
</section>

<div class="container-fluid">

<div class="row">
        <div class="col-md-6">

          <div class="card" style="margin-top:20px;">                        
              <div class="card-body">
              <div class="row">
             
                <div class="col-md-5">
                   Member ID
                   <asp:TextBox ID="ClID" runat="server"></asp:TextBox>
                </div>
                

                <div class="col-md-5">
                  Vehicle Plate #
                  <asp:TextBox ID="Lnamepfl" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-2">
                    <asp:Button class="btn btn-primary" ID="Look1" runat="server" Text="LOOK UP" style="margin-top:20px;" OnClick="Look1_Click"/>
                </div>
               </div>







               <div class="row">
                <div class="col-md-6">
                   First Name
                   <asp:TextBox ID="Fnme" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                

                <div class="col-md-6">
                  Last Name
                  <asp:TextBox ID="Lnme" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
               </div>

                <div class="row"> <!--Vehicle Make & Model Row-->
                    <div class="col-md-6">
                        Vehicle Make
                        <asp:TextBox ID="make" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                                   
                    <div class="col-md-6">
                        Vehicle Model
                        <asp:TextBox ID="model" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                 </div>



                <div class="row">
                 <div class="col-md-6">
                  Start Date
                 <asp:TextBox ID="UsrPfl" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                

                  <div class="col-md-6">
                  End Date
                  <asp:TextBox ID="Nwpss" runat="server" TextMode="Date"></asp:TextBox>
                </div>
               </div>



                <div class="row">
                <div class="col-md-6">
                     <asp:Button class="btn btn-primary" ID="Update" runat="server" Text="RETURN VEHICLE" style="margin-top:20px;"/>
                </div>
                

                  <div class="col-md-6">
                  <asp:Button class="btn btn-success" ID="issue" runat="server" Text="ISSUE VEHICLE" style="margin-top:20px;" OnClick="issue_Click"/>
                  </div>
                  </div>



                   

                
              </div> <!--This Ends Card BODY-->
        </div>
      </div> 
        <!--End col-->
<!--This Ends CARD to the left-->     

<!--This is the start of the second CARD to the right-->
<div class="col-md-6">
         <div class="card" style="margin-top:20px;">
              <center>
                  <h4>Rented Vehicle List</h4>
                  <br />
                  <hr style="width:50%;"/>
             <!-- This is where the account STATUS indicator is--> <!--Class="Badge" is BOOTSTRAP-->
              </center>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KMCarRentalDBConnectionString2 %>" SelectCommand="SELECT * FROM [Rentals]"></asp:SqlDataSource>

             <!--<div id="rentedVehicles">
    <asp:GridView ID="GridViewRental" runat="server" AutoGenerateColumns="False" CssClass="table">
        <HeaderStyle BackColor="#5cb85c" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#f9f9f9" />
        <Columns>
            <asp:BoundField DataField="RentalID" HeaderText="Rental ID" SortExpression="RentalID" />
            <asp:BoundField DataField="AdminID" HeaderText="Admin ID" SortExpression="AdminID" />
            <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" SortExpression="CustomerID" />
            <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" SortExpression="TotalCost" DataFormatString="{0:C}" />
            <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" SortExpression="PaymentMethod" />
        </Columns>
    </asp:GridView>
</div>-->


            <div class="card-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RentalID" DataSourceID="SqlDataSource1" class="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="RentalID" HeaderText="RentalID" ReadOnly="True" SortExpression="RentalID" />
                        <asp:BoundField DataField="AdminID" HeaderText="AdminID" SortExpression="AdminID" />
                        <asp:BoundField DataField="DriversNumber" HeaderText="DriversNumber" SortExpression="DriversNumber" />
                        <asp:BoundField DataField="Chassis_Number" HeaderText="Chassis_Number" SortExpression="Chassis_Number" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                        <asp:BoundField DataField="TotalCost" HeaderText="TotalCost" SortExpression="TotalCost" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="PaymentMethod" SortExpression="PaymentMethod" />
                    </Columns>
                </asp:GridView>          
           </div>      
     </div>
</div>
</div>
</div>


























</asp:Content>
