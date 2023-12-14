<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="Rent_Vehicle.aspx.cs" Inherits="km_Auto_Rental.Rent_Vehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
<div class="instructions">
    <center>
        <h2>How To Rent A Vehicle</h2>
        <p>1. Choose a vehicle from the Inventory list to the right.</p>
        <p>2. Enter the vehicle license plate number in the "Vehicle Plate #" box.</p>
        <p>3. Click on the "LOOK UP" button.</p>
        <p>4. Enter your member ID.</p>
        <p>5. Enter your name.</p>
        <p>6. Enter the date that you want to start the vehicle rental then enter the end date.</p>
        <p>7. Click the "RENT VEHICLE" button.</p>
        <p>Now you can come in and pick up your vehicle, no waiting, no long lines.</p>
    </center>
</div>
<div class="container-fluid">
    <div class="row">
        <div class="col-md-6">
            <div class="card" style="margin-top:20px;">                        
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-9">
                            Vehicle Plate #
                            <asp:TextBox ID="Lnamepfl" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button class="btn btn-primary" ID="Look1" runat="server" Text="LOOK UP" style="margin-top:20px;"/>
                        </div>
                    </div>
                    <!-- Rest of your existing code -->
                </div> <!--This Ends Card BODY-->
            </div>
        </div> 
        <!--End col-->

        <!--This is the start of the second CARD to the right-->
        <div class="col-md-6">
            <div class="card" style="margin-top:20px;">
                <center>
                    <h4>Available Vehicles</h4>
                    <br />
                    <hr style="width:50%;"/>
                    <!-- This is where the account STATUS indicator is--> <!--Class="Badge" is BOOTSTRAP-->
                </center>
                <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>          
                </div>      
            </div>
        </div>
    </div>
</div>


</asp:Content>
