<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="User-Profile.aspx.cs" Inherits="km_Auto_Rental.User_Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<section style="background-image: url('Images/Contact-blue.jpg');"> 
    <div id="hometop">
     <div class="container text-center">
        <div class="row align-items-end">
            <div class="col">
             <h2><strong>USER PROFILE</strong></h2>
        </div>
       </div>
         </div>
        </div>
</section>

<div class="container-fluid">

<div class="row">
        <div class="col-md-6">

          <div class="card" style="margin-top:20px;">
              <center>
                  <h4>User Profile</h4>
                  <br />
                  <hr style="width:50%;"/>
             <!-- This is where the account STATUS indicator is--> <!--Class="Badge" is BOOTSTRAP-->
              <span>Account Status - </span>
              <asp:Label class="badge rounded-pill text-bg-info" ID="stats" runat="server" Text="Status"></asp:Label>
              </center>
            
              <div class="card-body">
              <div class="row">
             
                <div class="col-md-6">
                   First Name
                   <asp:TextBox ID="Fnmprl" runat="server"></asp:TextBox>
                </div>
                

                <div class="col-md-6">
                  Last Name
                  <asp:TextBox ID="Lnamepfl" runat="server"></asp:TextBox>
                </div>
               </div>


               <div class="row">
                <div class="col-md-6">
                   Phine #
                   <asp:TextBox ID="PhnPfl" runat="server"></asp:TextBox>
                </div>
                

                <div class="col-md-6">
                  Email
                  <asp:TextBox ID="EmlPfl" runat="server"></asp:TextBox>
                </div>
               </div>
                <div class="row">
                    <div class="col-md-12">
                        Drivers License #
                        <asp:TextBox ID="DLpfl" runat="server"></asp:TextBox>
                    </div>
                 </div>

                <hr />
                 <center>
                   <asp:Label class="badge rounded-pill text-bg-info" ID="credential" runat="server" Text="Login Credentials"></asp:Label>
                 </center>
                <hr />
                <div class="row">
                 <div class="col-md-4">
                   Username
                   <asp:TextBox ID="UsrPfl" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                

                <div class="col-md-4">
                  Password
                  <asp:TextBox ID="PassPfl" runat="server" ReadOnly="True"></asp:TextBox>
                </div>

                    <div class="col-md-4">
                  New Password
                  <asp:TextBox ID="Nwpss" runat="server"></asp:TextBox>
                </div>
               </div>
                   <asp:Button class="btn btn-success" ID="Update" runat="server" Text="UPDATE" style="margin-top:20px;"/>

                
              </div> <!--This Ends Card BODY-->
        </div>
      </div> 
        <!--End col-->
<!--This Ends CARD to the left-->     

<!--This is the start of the second CARD to the right-->
<div class="col-md-6">
         <div class="card" style="margin-top:20px;">
              <center>
                  <h4>Your Current Rented Car</h4>
                  <br />
                  <hr style="width:50%;"/>
             <!-- This is where the account STATUS indicator is--> <!--Class="Badge" is BOOTSTRAP-->
              
              <asp:Label class="badge rounded-pill text-bg-info" ID="Rentinfo" runat="server" Text="Info About Cars & Due Dates"></asp:Label>
              </center>



            <div class="card-body">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KMCarRentalDBConnectionString4 %>" SelectCommand="SELECT * FROM [Rentals]"></asp:SqlDataSource>
                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RentalID" DataSourceID="SqlDataSource1">
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
