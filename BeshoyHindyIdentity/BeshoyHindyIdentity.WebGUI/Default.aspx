<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebGUI.Default" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>


<!DOCTYPE html>
<html lang="en-US" class="no-js" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="target-densitydpi=device-dpi, initial-scale=1.0, user-scalable=no" />
    <meta name="description" content="Bootstrap One Page HTML5/CSS3 Parallax Resume Template" />
    <meta name="author" content="TheThemeLab" />
    <title>Beshoy Hindy - Portfolio</title>
    <!-- Favicons -->
    <link rel="shortcut icon" href="img/ico-16.ico" />
    <link rel="apple-touch-icon" href="img/ico-57.png" sizes="57x57" />
    <link rel="apple-touch-icon" href="img/ico-72.png" sizes="72x72" />
    <link rel="apple-touch-icon" href="img/ico-114.png" sizes="114x114" />
    <link rel="apple-touch-icon" href="img/ico-144.png" sizes="144x144" />
    <!-- List of Stylesheet -->
    <link type='text/css' href="css/normalize.css" rel="stylesheet" />
    <link type='text/css' href="css/bootstrap.min.css" rel="stylesheet" />
    <link type='text/css' href="css/font-awesome.min.css" rel="stylesheet" />
    <link type='text/css' href="css/style.css" rel="stylesheet" />
    <link type='text/css' href="css/style-responsive.css" rel="stylesheet" />
    <!-- Google Font -->
    <link href='http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,600,700,400italic,600italic,700italic' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Oswald:400,300,700' rel='stylesheet' type='text/css' />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
          <script src="js/html5shiv.js"></script>
          <script src="js/respond.min.js"></script>
        <![endif]-->
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
</head>
<body data-spy="scroll" data-target=".navbar">
    <!-- Pre-loader -->
    <div class="mask">
        <div id="intro-loader">
        </div>
    </div>
    <!-- End Pre-loader -->

    <!-- Navbar -->
    <div class="navbar navbar-transparent navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <img class="logo" src="images/logo.png" alt="" /></a>
            </div>
            <nav id="my-nav" class="navbar-collapse collapse" role="navigation">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="#home">Home</a>
                    </li>
                    <li>
                        <a href="#about">About</a>
                    </li>
                    <li>
                        <a href="#portfolio">Works</a>
                    </li>
                    <li>
                        <a href="#skill">Skills</a>
                    </li>
                    <li>
                        <a href="#experience">Resume</a>
                    </li>
                    <li>
                        <a href="#clients">Clients</a>
                    </li>
                    <li>
                        <a href="#process">Process</a>
                    </li>
                    <li>
                        <a href="#contact">Contact</a>
                    </li>
                </ul>
            </nav>
            <!--/.navbar-collapse -->
        </div>
    </div>
    <!-- End Navbar -->

    <!-- Home Section -->
    <section id="home">
        <img id="cycle-loader" src="img/loader.gif" alt="loader" />
        <div id="fullscreen-slider">
            <!-- Slider image 1-->
            <div class="slider-item">
                <img src="images/slide1.jpg" alt="">
            </div>
            <!-- End Slider image 1-->
            <!-- Slider image 2-->
            <div class="slider-item">
                <img src="images/slide2.jpg" alt="">
            </div>
            <!-- End Slider image 2-->
        </div>
        <div class="slide-content">
            <div class="text-center">
                <div class="header">
                    <div class="heading">
                        Welcome to my Portfolio
		
                    </div>
                    <div class="box-heading">
                        <div class="box-inner">
                            Beshoy Hindy
			
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Home Section -->
    <form id="form1" runat="server">
        <!-- About Section -->
        <section id="about" class="section-content bg1">
            <div class="container">
                <div class="row">
                    <!-- Section Title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-user fa-2x"></span>
                        </div>
                        <h1>About <span>Me</span></h1>
                    </div>
                    <!-- End Section Title -->
                </div>
                <div class="row">
                    <div class="col-md-4 text-center item_bottom">
                        <%--<img src="images/photo.jpg" class="img-center img-responsive" alt="My photo" />--%>
                        <asp:Image ID="imgImageFile" CssClass="img-center img-responsive" runat="server" />
                        <!-- YOUR PHOTO -->
                        <div class="name-title">
                            <h2>
                                <asp:Literal ID="lblName" Text="Jonathan Doe" runat="server" /></h2>
                            <!-- Your Name -->
                            <h5>
                                <asp:Literal ID="lblJobTitle" Text="UI/UX Designer" runat="server" /></h5>
                            <!-- Your Designation -->
                        </div>
                    </div>
                    <div class="col-md-4 item_top">
                        <p class="quoteline">
                            <asp:Literal ID="lblQuote" Text="  Be who you are and say what you feel, because those who mind don't matter, and those who matter don't mind." runat="server" />
                        </p>
                        <p>
                            <asp:Literal ID="lblIdentityDescription" Text="Hello, I'm a UI/UX Designer & Front End Developer from Dhaka, Bangladesh. I hold a master degree of Web Design from the St. Patrick University." runat="server" />
                        </p>
                        <%-- <p class="text-right">
                            <img src="images/signature.png" alt="signature" />
                        </p>--%>
                    </div>
                    <div class="col-md-4 item_bottom">
                        <ul class="fa-ul">
                            <li><i class="fa fa-li fa-calendar"></i><strong>Birthdate</strong> :
                                <asp:Literal ID="lblBirthDate" Text="02/09/1982" runat="server" /></li>
                            <li><i class="fa fa-li fa-mobile"></i><strong>Phone</strong> :
                                <asp:Literal ID="lblPhone" Text="+1 343-234-4343" runat="server" /></li>
                            <li><i class="fa fa-li fa-envelope-o"></i><strong>Email</strong> :
                                <asp:Literal ID="lblEmail" Text="john@example.com" runat="server" /></li>
                            <li><i class="fa fa-li fa-globe"></i><strong>Website</strong> :
                                <asp:Literal ID="lblWebsite" Text="www.example.com" runat="server" /></li>
                            <li><i class="fa fa-li fa-home"></i><strong>Adresse</strong> :
                                <asp:Literal ID="lblAddress" Text='12 Segun Bagicha, 10th Floor,<br> Dhaka 1000, Bangladesh.' runat="server" /></li>
                        </ul>

                        <div class="number-counters text-center new-line">
                            <%--<div class="counters-item">
                                <i class="fa fa-group fa-2x"></i>
                                <strong data-to="150">0</strong>
                                <!-- Set Your Number here. i,e. data-to="56" -->
                                <p>
                                    Happy Clients
				
                                </p>
                            </div>--%>
                            <div class="counters-item">
                                <i class="fa fa-flag fa-2x"></i>
                                <strong data-to='<%=YearExperiance%>'>0</strong>
                                <!-- Set Your Number here. i,e. data-to="56" -->
                                <p>
                                    Year Experience
				
                                </p>
                            </div>
                            <%--<div class="counters-item">
                                <i class="fa fa-trophy fa-2x"></i>
                                <strong data-to="13">0</strong>
                                <!-- Set Your Number here. i,e. data-to="56" -->
                                <p>
                                    Awards Won
				
                                </p>
                            </div>--%>
                            <div class="counters-item">
                                <i class="fa fa-thumbs-up fa-2x"></i>
                                <strong data-to='<%=ProjectsNumber%>'>0</strong>
                                <!-- Set Your Number here. i,e. data-to="56" -->
                                <p>
                                    Projects Done
				
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row services">
                    <div class="col-md-4">
                        <!-- Service -->
                        <div class="services-box new-line item_left">
                            <h4>Customer Support</h4>
                            <div class="services-box-icon">
                                <i class="fa fa-smile-o fa-3x"></i>
                            </div>
                            <div class="service-box-info">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque rutrum pellesque imperdiet. Nulla lacinia iaculis nulla.
				
                                </p>
                            </div>
                        </div>
                        <!-- End Service -->
                    </div>
                    <div class="col-md-4">
                        <!-- Service -->
                        <div class="services-box new-line item_bottom">
                            <h4>Web Design</h4>
                            <div class="services-box-icon">
                                <i class="fa fa-html5 fa-3x"></i>
                            </div>
                            <div class="service-box-info">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque rutrum pellesque imperdiet. Nulla lacinia iaculis nulla.
				
                                </p>
                            </div>
                        </div>
                        <!-- End Service -->
                    </div>
                    <div class="col-md-4 clearfix">
                        <!-- Service -->
                        <div class="services-box new-line item_right">
                            <h4>Wordpress Themes</h4>
                            <div class="services-box-icon">
                                <i class="fa fa-link fa-3x"></i>
                            </div>
                            <div class="service-box-info">
                                <p>
                                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque rutrum pellesque imperdiet. Nulla lacinia iaculis nulla.
				
                                </p>
                            </div>
                        </div>
                        <!-- End Service -->
                    </div>
                </div>
            </div>
        </section>
        <!-- End About Section -->

        <!-- Portfolio Section -->
        <section id="portfolio" class="section-content bg3">
            <div class="container">
                <div class="row">
                    <!-- Section title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-briefcase fa-2x"></span>
                        </div>
                        <h1 class="white">My <span>Works</span></h1>
                    </div>
                    <!-- End Section title -->
                </div>
                <div class="portfolio-top">
                </div>
                <div id="portfolio-wrap">
                    <div id="portfolio-page">
                        <div id="portfolio-content">
                            <div class="container">
                                <div class="row">
                                    <div id="protfolio-control">
                                        <div class="row">
                                            <div class="col-md-4 col-sm-4 col-xs-4">
                                                <a href="#" id="prev-project" title="Previous Project"><i class="fa fa-arrow-left"></i></a>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-4 text-center">
                                                <a href="#" id="close-project" title="Close Project"><i class="fa fa-times"></i></a>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-xs-4 text-right">
                                                <a href="#" id="next-project" title="Next Project"><i class="fa fa-arrow-right"></i></a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End #protfolio-control -->
                                    <!-- Ajax will load into here -->
                                    <div id="portfolio-ajax">
                                    </div>
                                    <!-- End #portfolio-ajax -->
                                    <!-- End Ajax -->
                                </div>
                            </div>
                        </div>
                        <!-- End #portfolio-content -->
                    </div>
                    <!-- End #portfolio-page -->
                </div>
                <!-- End #portfolio-wrap -->
                <div id="portfolio-filter">
                    <div class="row text-center">
                        <div class="col-md-12">
                            <!--portfolio category-->
                            <ul class="portfolio-filter-list white">
                                <li>
                                    <a class="active" href="#" data-cat="*">ALL</a>
                                </li>

                                <asp:Repeater ID="rptrWorkType" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <%--<a href="#" data-cat="design">Design</a>--%>
                                            <a href="#" data-cat='<%#Eval("Id").ToString() %>'><%#Eval("TypeName") %></a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <!--End portfolio category-->
                        </div>
                        <!-- End .col-md-12 -->
                    </div>
                    <!-- End .row -->
                </div>
            </div>
            <!-- End .container -->

            <!-- End #portfolio-filter -->
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="portfolio-items" class="portfolio-items item_fade_in">
                            <asp:Repeater ID="rptrWorks" runat="server">
                                <ItemTemplate>
                                    <article class='<%#Eval("WorkTypeId").ToString() %>'>
                                        <a href="#!ProjectDetails.aspx">
                                            <img src='<%#ConfigurationManager.AppSettings["PoortfolioUI"].ToString() + Eval("IamgeThumb") %>' alt="Portfolio" />
                                            <div class="overlay">
                                                <div class="item-info">
                                                    <i class="fa fa-camera"></i>
                                                    <h3><%#Eval("Title") %>'</h3>
                                                    <span><%#Eval("TypeName") %></span>
                                                </div>
                                            </div>
                                            <!-- End .overlay -->
                                        </a>
                                    </article>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- End #portfolio-items.portfolio-items -->
                    </div>
                </div>
            </div>
        </section>
        <!-- End Portfolio Section -->

        <!-- Skill Section -->
        <section id="skill" class="section-content bg2">
            <div class="container">
                <div class="row">
                    <!-- Section Title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-bar-chart-o fa-2x"></span>
                        </div>
                        <h1>My <span>Skills</span></h1>
                    </div>
                    <!-- End Section Title -->
                </div>
                <div class="row text-center item_bottom">
                    <asp:Repeater ID="rptrSoftWareSkilles" runat="server">
                        <ItemTemplate>
                            <div class="col-md-2">
                                <div class="chart" data-percent='<%#Eval("Percentage") %>'>
                                    <span class="percent"><%#Eval("Percentage") %></span>
                                    <h4><%#Eval("Title") %></h4>
                                    <p>
                                        <%#Eval("Description") %>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row new-line item_bottom">
                    <div class="col-md-6">
                        <ul class="skillBar">

                            <asp:Repeater ID="rptrOddsGeneralSkilles" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="skillBg">
                                            <span data-width='<%#Eval("Percentage") %>'><strong><%#Eval("Title")  %>  <%#Eval("Percentage")  %>%</strong></span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="col-md-6">
                        <ul class="skillBar">

                            <asp:Repeater ID="rptrEvenGeleralSkilles" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <div class="skillBg">
                                            <span data-width='<%#Eval("Percentage") %>'><strong><%#Eval("Title")  %>  <%#Eval("Percentage")  %>%</strong></span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <!-- skills end -->
            </div>
        </section>
        <!-- End Skill Section -->

        <!-- I am available Section-->
        <div class="fullwidth-section bg-callout">
            <div class="container">
                <div class="col-md-12 text-center item_bottom">
                    <h1 class="white padBottom killMargin">I am available for <strong>Freelancer</strong></h1>
                    <a href="#contact" class="scroll btn btn-trans btn-border-w btn-large">Hire Me</a>&nbsp;&nbsp;<a class="btn btn-primary btn-lg" href="#"><i class="fa fa-download"></i> Download Resume</a>
                </div>
            </div>
        </div>
        <!-- End I am available Section -->

        <!-- Resume Section -->
        <section id="experience" class="section-content bg2">
            <div class="container">
                <div class="row">
                    <!-- Section title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-book fa-2x"></span>
                        </div>
                        <h1>My <span>Resume</span></h1>
                    </div>
                    <!-- End Section title -->
                </div>
                <div class="row">
                    <ul class="timeline list-unstyled">
                        <!-- History Year -->
                        <li class="title">Present</li>
                        <asp:Literal ID="lblResumes" runat="server" />
                        <%--                        <li class="note item_right">
                            <h4>Creative Agency</h4>
                            <h5>Project Manager</h5>
                            <p class="desc">
                                Lorem Ipsum roin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat.
		
                            </p>
                            <span class="date">DEC 2013 to Present</span>
                            <span class="arrow fa fa-play"></span>
                        </li>
                        <li class="note item_left">
                            <h4>Infosys</h4>
                            <h5>UI/UX Designer</h5>
                            <p class="desc">
                                Lorem Ipsum roin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat.
		
                            </p>
                            <span class="date">JUN 2012 to NOV 2013 </span>
                            <span class="arrow fa fa-play"></span>
                        </li>
                        <li class="note item_right">
                            <h4>Micro Web Planet</h4>
                            <h5>Web Developer</h5>
                            <p class="desc">
                                Lorem Ipsum roin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat. Photoshop's version of Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, quis bibendum auctor, nisi elit consequat.
		
                            </p>
                            <span class="date">Jan 2012 MAY 2012 </span>
                            <span class="arrow fa fa-play"></span>
                        </li>
                        <li class="note item_left">
                            <h4>Creative Solution</h4>
                            <h5>Web Designer</h5>
                            <p class="desc">
                                Lorem Ipsum roin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat. Proin gravida nibh vel velit auctor aliquet. Aenean sollicitudin, lorem quis bibendum auctor, nisi elit consequat.
		
                            </p>
                            <span class="date">Jan 2011 to Dec 2012 </span>
                            <span class="arrow fa fa-play"></span>
                        </li>--%>
                        <!-- Education -->
                        <li class="title">Education</li>
                        <asp:Literal ID="lblEducation" runat="server" />
                        <%-- <li class="note item_left">
                            <h4>Master Degree of Computer Science</h4>
                            <h5>Oxford University</h5>
                            <p class="desc">
                                This is Photoshop's version Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.
		
                            </p>
                            <span class="date">2012 - 2013 </span>
                            <span class="arrow fa fa-play"></span>
                        </li>
                        <li class="note item_right">
                            <h4>Bechelor Degree of Computer Science</h4>
                            <h5>Oxford University</h5>
                            <p class="desc">
                                Lorem Ipsum. This is Photoshop's version Lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.
		
                            </p>
                            <span class="date">2007 - 2011 </span>
                            <span class="arrow fa fa-play"></span>
                        </li>--%>
                        <!-- Start icon -->
                        <li class="start fa fa-bookmark"></li>
                        <li class="clear"></li>
                    </ul>
                </div>
            </div>
        </section>
        <!-- End Experience Timeline Section -->

        <!-- Clients Section -->
        <section id="clients" class="clients parallax" style="background-image: url(images/clients.jpg)">
            <div class="parallax-overlay">
                <div class="container">
                    <div class="row">
                        <!-- Section title -->
                        <div class="section-title item_bottom text-center">
                            <div>
                                <span class="fa fa-users fa-2x"></span>
                            </div>
                            <h1 class="white">My <span>Clients</span></h1>
                        </div>
                        <!-- End Section title -->
                    </div>
                    <div class="row item_bottom">
                        <h4 class="white">What my <strong>clients saying</strong></h4>
                        <div class="col-lg-6 col-lg-offset-3 col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 col-xs-10 col-xs-offset-1">
                            <div class="swiper-testimonial">
                                <div class="swiper-wrapper">
                                    <asp:Repeater ID="rptrClientsSayes" runat="server">
                                        <ItemTemplate>
                                            <div class="swiper-slide">
                                                <p class="quote"><%#Eval("ClientMessage") %></p>
                                                <p class="author"><%#Eval("ClientName") %></p>
                                                <p class="company"><%#Eval("ClientPosition") %> <a href='<%#Eval("ClientURL") %>' target="_blank">@<%#Eval("ClientName") %></a></p>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <%--                                    <!--First Slide-->
                                    <div class="swiper-slide">
                                        <p class="quote">"It’s easy to see the passion that the guys have for their work. He really care about making unique designs for their clients, and put in incredible effort to make the whole process a real pleasure."</p>
                                        <p class="author">Jak Doe</p>
                                        <p class="company">CEO <a href="#">@Intel</a></p>
                                    </div>

                                    <!--Second Slide-->
                                    <div class="swiper-slide">
                                        <p class="quote">"My website couldn’t look better after working with the him on the redesign. Now my site and corporate	branding is outstanding! He is awesome."</p>
                                        <p class="author">John Doe</p>
                                        <p class="company">Manager <a href="#">@Web Planet</a></p>
                                    </div>

                                    <!--Third Slide-->
                                    <div class="swiper-slide">
                                        <p class="quote">"I am incredibly happy with the increased traffic my site has received since working with you! He is the best at this job."</p>
                                        <p class="author">Jane Doe</p>
                                        <p class="company">Owner <a href="#">@Creative Agency</a></p>
                                    </div>--%>
                                </div>
                                <!--/ .swiper-wrapper -->
                                <div class="pagination-testimonial"></div>
                                <!--/ swiper slider pagination -->
                            </div>
                            <!--/ .swiper-testimonial -->
                        </div>

                    </div>
                    <!--/ .row -->
                    <div class="row new-line item_fade_in">
                        <h4 class="white">Some of my <strong>awesome clients</strong></h4>
                        <div class="carrousel-container">
                            <div id="left_scroll"><a href="#"></a></div>
                            <div id="carousel_inner">
                                <ul class="clearfix" id="carousel_ul">
                                    <asp:Repeater ID="rptrClientsLogo" runat="server">
                                        <ItemTemplate>
                                            <li><span>
                                                <a href='<%#Eval("ClientURL") %>' target="_blank">
                                                    <img src='<%#ConfigurationManager.AppSettings["ClientsUI"].ToString() + Eval("Logo") %>' alt='<%#Eval("ClientName") %>'></a></span></li>
                                            <li><span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <%-- <li><span>
                                        <img src="images/clients/twitter.png" alt="Twitter"></span></li>
                                    <li><span>
                                        <img src="images/clients/magento.png" alt="magento"></span></li>
                                    <li><span>
                                        <img src="images/clients/mailchimp.png" alt="mailchimp"></span></li>
                                    <li><span>
                                        <img src="images/clients/nexternal.png" alt="nexternal"></span></li>
                                    <li><span>
                                        <img src="images/clients/wordpress.png" alt="wordpress"></span></li>
                                    <li><span>
                                        <img src="images/clients/google.png" alt="google"></span></li>--%>
                                </ul>
                            </div>
                            <div id="right_scroll"><a href="#"></a></div>
                            <input type="hidden" id="hidden_auto_slide_seconds" value="0" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Clients Section -->

        <!-- Process Section -->
        <section id="process" class="section-content bg3">
            <div class="container">
                <div class="row">
                    <!-- Section title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-cogs fa-2x"></span>
                        </div>
                        <h1 class="white">My <span>Process</span></h1>
                    </div>
                    <!-- End Section title -->

                    <ol class="process-flow list-unstyled">

                        <asp:Repeater ID="rptrProcess" runat="server">
                            <ItemTemplate>
                                <li class="active">
                                    <div class="process-node active">
                                        <i class="fa <%#Eval("Logo") %>"></i>
                                    </div>
                                    <h4><%#Eval("Title") %></h4>
                                    <p><%#Eval("Description") %></p>
                                    <div class="line">
                                        <div class="progress"></div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%-- <li class="active">
                            <div class="process-node active">
                                <i class="fa fa-comments"></i>
                            </div>
                            <h4>Discussion</h4>
                            <p>Lorem Ipsum lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.</p>
                            <div class="line">
                                <div class="progress"></div>
                            </div>
                        </li>
                        <li class="active">
                            <div class="process-node active">
                                <i class="fa fa-lightbulb-o"></i>
                            </div>
                            <h4>Idea</h4>
                            <p>Lorem Ipsum lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.</p>
                            <div class="line">
                                <div class="progress"></div>
                            </div>
                        </li>
                        <li class="active">
                            <div class="process-node active">
                                <i class="fa fa-desktop"></i>
                            </div>
                            <h4>Implementation</h4>
                            <p>Lorem Ipsum lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.</p>
                            <div class="line">
                                <div class="progress"></div>
                            </div>
                        </li>
                        <li class="active">
                            <div class="process-node active">
                                <i class="fa fa-flash"></i>
                            </div>
                            <h4>Review</h4>
                            <p>Lorem Ipsum lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.</p>
                            <div class="line">
                                <div class="progress"></div>
                            </div>
                        </li>
                        <li class="active">
                            <div class="process-node active">
                                <i class="fa fa-rocket"></i>
                            </div>
                            <h4>Deliver</h4>
                            <p>Lorem Ipsum lorem Ipsum. Proin gravida nibh vel velit auctor aliquet.</p>
                        </li>--%>
                    </ol>
                </div>
            </div>
        </section>
        <!-- End Process Section -->

        <!-- Contact Section -->
        <asp:ScriptManager ID="scrptmgr" runat="server" />
        <section id="contact" class="section-content bg2">
            <div class="container">
                <div class="row">
                    <!-- Section title -->
                    <div class="section-title item_bottom text-center">
                        <div>
                            <span class="fa fa-envelope fa-2x"></span>
                        </div>
                        <h1>Get in <span>touch</span></h1>
                    </div>
                    <!-- End Section title -->
                </div>
                <div class="row item_fade_in">
                    <div class="col-md-6 col-md-offset-3 text-center contact-block">
                        <!-- Contact Details -->
                        <i class="fa fa-map-marker fa-3x"></i>
                        <p>
                            <asp:Literal ID="lblAddress_ContactSection" runat="server" />
                        </p>
                        <p>
                            <asp:Literal ID="lblPhone_ContactSection" runat="server" />
                        </p>
                        <!-- End Contact Details -->
                        <!-- Social Icon -->
                        <div class="social-icon">
                            <asp:Repeater ID="rptrSocialLinks" runat="server">
                                <ItemTemplate>
                                    <a href='<%#Eval("URl") %>' target="_blank"><i class='fa <%# Eval("Logo") %> fa-3x'></i></a>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--<a href="#"><i class="fa fa-facebook-square fa-3x"></i></a>
                                <a href="#"><i class="fa fa-twitter-square fa-3x"></i></a>
                                <a href="#"><i class="fa fa-google-plus-square fa-3x"></i></a>
                                <a href="#"><i class="fa fa-linkedin-square fa-3x"></i></a>
                                <a href="#"><i class="fa fa-pinterest-square fa-3x"></i></a>
                                <a href="#"><i class="fa fa-vimeo-square fa-3x"></i></a>--%>
                        </div>
                        <!-- End Social Icon -->
                    </div>
                </div>

                <div class="row item_fade_in">

                    <h4 class="text-center">Drop me a Line</h4>
                    <div class="col-md-6 col-md-offset-3">
                        <div class="form-respond text-center">
                        </div>
                        <%--<form method="post" name="contactform" id="contactform" class="form validate item_bottom" role="form">--%>

                        <div class="form-group">
                            <input type="text" name="name" id="name" class="form-control required" placeholder="Name" />
                        </div>
                        <div class="form-group">
                            <input type="email" name="email" id="email" class="form-control required email" placeholder="Email" />
                        </div>
                        <div class="form-group">
                            <textarea name="message" id="message" class="form-control input-lg required" rows="9" placeholder="Enter Message"></textarea>
                        </div>
                        <div class="form-group text-center">
                            <asp:Button ID="contactForm_submit" Text="Send" CssClass="btn btn-trans btn-border btn-full" runat="server" OnClick="contactForm_submit_Click" />

                            <%-- <input type="submit"  class=" value="Submit">--%>
                        </div>
                        <input type="hidden" name="subject" value="Contact from your site" />
                        <%--			</form>--%>
                    </div>
                </div>
                <!-- End form contact -->
            </div>
        </section>
        <!-- End Contact Section -->
    </form>
    <!-- Google maps -->
    <div id="map_canvas" class="item_fade_in">
    </div>
    <!-- End Google maps -->
    <footer class="text-center">
        <!-- Footer Text -->
        <div class="container text-center item_top">
            <img class="footer-logo" src="images/logo.png" alt="footer logo"><br />
            &copy; Copyright 2014. All Rights Reserved.

        </div>
        <!-- End Footer Text -->
    </footer>
    <!-- Back to top -->
    <a href="#" id="back-top"><i class="fa fa-angle-up fa-2x"></i></a>
    <!-- Js Library -->
    <script type="text/javascript" src="js/modernizr.js"></script>
    <script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.sticky.js"></script>
    <script type="text/javascript" src="js/jquery.easing-1.3.pack.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/bootstrap-modal.js"></script>
    <script type="text/javascript" src="js/jquery.parallax-1.1.3.js"></script>
    <script type="text/javascript" src="js/jquery.appear.js"></script>
    <script type="text/javascript" src="js/jquery.cycle.all.js"></script>
    <script type="text/javascript" src="js/jquery.flexslider.min.js"></script>
    <script type="text/javascript" src="js/jquery.fitvids.js"></script>
    <script type="text/javascript" src="js/jquery.maximage.js"></script>
    <script type="text/javascript" src="js/swiper.min.js"></script>
    <script type="text/javascript" src="js/waypoints.min.js"></script>
    <script type="text/javascript" src="js/jquery-countTo.js"></script>
    <script type="text/javascript" src="js/easyPieChart.js"></script>
    <script type="text/javascript" src="js/smoothscroll.js"></script>
    <script type="text/javascript" src="js/skrollr.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.min.js"></script>
    <script type="text/javascript" src="js/jquery.nicescroll.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="js/gmap-settings.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <!-- Js Library -->
</body>
</html>
