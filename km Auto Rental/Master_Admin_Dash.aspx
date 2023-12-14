<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page.Master" AutoEventWireup="true" CodeBehind="About Us.aspx.cs" Inherits="km_Auto_Rental.About_Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style.css" rel="stylesheet" />

<section style="background-image: url('Images/About-blue.jpg');"> 
<div id="hometop">
 <div class="container text-center">
  <div class="row align-items-end">
    <div class="col">
      <h1><strong>ABOUT US</strong></h1>
        <p>.</p>
    </div>
    
    <div class="col">
      <<img src="Images/KM%20Logo.png" class="img-fluid" /> <!--The 'CLASS FLUID' in this line is Bootstrap to make the image responsive-->
    </div>
  </div>
 </div>
</div>
</section> <!--Section 1 with the blue background-->


<div class="fr" >
       <div class="row">
        <div class="col-md-6">
           <h4>Mission Statement</h4>
           <p>At KM Auto Rental, we are driven by our dedication to provide reliable vehicles for every journey, ensuring that every customer experiences the pinnacle of convenience, safety, and value.</p>
        </div><!--End col-->
      
<div class="col-md-6">
        <h4>Who We Are</h4>
        <p>KM Auto Rental is a Jamaican based car rental and airport pick up company started in 2023. We offer services like car rental with a wide range of options to choose from, our fleet has vehicles from small as Honda Fit abd as bog as Toyota Hiace bus. Our main office is located in Kingston Jamaica and we are open from 8:00am to 5:00pm. 
        <p>When you choose KM Auto Rental, you are not just renting a car; you are gaining the confidence to explore your destination freely.</p>

    </div> <!--End of Col-md-6-->      
   </div>
</div>



<div class="fr" >
       <div class="row">
           <center><h4>Why Choose Us</h4></center>
        <div class="col-md-6">
           <h4>1 - Extensive Fleet:</h4>
           <p>
               Our diverse fleet of vehicles ensures that you'll find the ideal ride to match your preferences and requirements. From fuel-efficient compact cars for city explorations to spacious SUVs for family adventures, we have it all.
           </p>
           
            
           <h4>2 - Convenient Airport Pick up:</h4>
           <p>
               Start your journey stress-free with our reliable airport pick-up service. Our friendly drivers will be waiting to greet you, assist with your luggage, and get you on the road without any delay.
           </p>


           <h4>3 - Simple Online Booking:</h4>
           <p>
               Our user-friendly online booking platform allows you to reserve your vehicle in just a few clicks. Select your desired car, specify pick-up and drop-off details, and leave the rest to us.
           </p>
          
           
           
           <h4>4 - Competitive Prices:</h4>
           <p>
             We believe that quality service shouldn't come at a high price. Enjoy affordable rates without compromising on the quality of your rental experience.
           </p>
           


            <h4>5 - Clean and Well-maintained Vehicles:</h4>
           <p>
               Your safety and comfort are our top priorities. All our vehicles are regularly inspected and maintained to ensure they are in pristine condition.
           </p>

            </div>
           
           
           
           <!--End col-->
      
<div class="col-md-6">
    <img src="Images/About-1-Side.jpg" class="img-fluid" />
    <img src="Images/Fleet-Of-Cars.jpg" class="img-fluid" />
    
    </div> <!--End of Col-md-6-->      
   </div>
</div>








</asp:Content>
