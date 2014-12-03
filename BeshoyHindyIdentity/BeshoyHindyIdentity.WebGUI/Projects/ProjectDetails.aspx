<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="WebGUI.Projects.ProjectDetails" %>

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


<%--<div class="single-portfolio">
    <div class="container">
        <div class="row">
            <div class="col-md-8" id="primary">
                <img alt="project1" src="images/portfolio/thumb1.jpg" class="img-responsive" />
            </div>

            <div class="col-md-4" id="secondary">
                <!-- Project Summary -->
                <div class="project-desc">
                    <h3>Project Details</h3>
                    <div class="line-strong"></div>
                    <ul class="list-details">
                        <li><i class="fa fa-calendar"></i>10 March 2014</li>
                        <li><i class="fa fa-tag"></i>video, logo</li>
                        <li><i class="fa fa-globe"></i><a href="#">Live Demo</a></li>
                    </ul>
                    <p>Lorem ipsum dolor sit amet consectetuer malesuada congue et suscipit condimentum. Nulla at malesuada mauris ornare neque tellus ac Aenean adipiscing felis. Vestibulum turpis Nam pede eget elit feugiat Vestibulum neque Curabitur justo. Donec cursus semper urna consectetuer Nam Vivamus ut Pellentesque mauris laoreet. Vitae magna in at Nulla sodales vitae wisi tincidunt libero laoreet.</p>
                </div>
                <!-- End Project Summary -->
            </div>
        </div>
        <!-- End .row -->
    </div>
    <!-- End .container -->
</div>--%>



<div class="single-portfolio">
    <div class="container">
        <div class="row">
            <div class="col-md-8" id="primary">
                <img id="imgIamgeFile" runat="server" alt="Project Photo" class="img-responsive" />
                <%--<asp:image id="imgIamgeFile" alt="Project Photo" cssclass="img-responsive" runat="server" />--%>
            </div>

            <div class="col-md-4" id="secondary">
                <!-- Project Summary -->
                <div class="project-desc">
                    <h3>
                        <asp:literal id="lblTitle" runat="server" />
                    </h3>
                    <div class="line-strong"></div>
                    <ul class="list-details">
                        <li><i class="fa fa-calendar"></i>
                            <asp:literal id="lblProjectDate" runat="server" />
                        </li>
                        <li><i class="fa fa-tag"></i>
                            <asp:literal id="lblWorkType" runat="server" />
                        </li>
                        <li><i class="fa fa-globe"></i><a id="hURL" target="_blank" runat="server">
                            <asp:literal id="lblTitle_URL" runat="server" />
                            URL</a></li>
                    </ul>
                    <p>
                        <asp:literal id="lblDescription" runat="server" />
                    </p>
                </div>
                <!-- End Project Summary -->
            </div>
        </div>
        <!-- End .row -->
    </div>
    <!-- End .container -->
</div>

