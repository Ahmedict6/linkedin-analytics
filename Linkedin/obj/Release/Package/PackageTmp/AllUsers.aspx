<%@ Page Title="linkedin |supplier Report" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="CustomerPortal.AllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat="server">


        <ContentTemplate>
            <asp:HiddenField ID="json" runat="server" Value="" />

            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Show All Profiles</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="allusers.aspx">Profiles</a>
                                </li>
                                
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                <div class="row" id="items">



                </div>

            </div>
            <script>




                function docReady(fn) {
                    // see if DOM is already available
                    if (document.readyState === "complete" || document.readyState === "interactive") {
                        // call on next available tick
                        setTimeout(fn, 1);
                    } else {
                        document.addEventListener("DOMContentLoaded", fn);
                    }
                }
                var count = 150;
                docReady(function () {

                    $(document).ready(function () {

                        $.ajax({
                            url: 'AllUsers.aspx/DataTableToJSONWithJSONNet',
                            method: 'post',
                            contentType: "application/json",
                            data: '{count:' + count + '}',
                            dataType: "json",
                           
                            success: function (data) {
                             
                                var x = data['d'];
                                x = JSON.parse(x)
                                //console.log();
                                for (i = 0 ; i <= x.length; i++) {
                                    var link = "Images/NoImageFound.jpg";
                                    if (x[0]['ImageUrl'] != null)
                                        link = x[i]['ImageUrl'];

                                    if (link == "")
                                        link = "Images/NoImageFound.jpg";

                                    $("#items").append('    <div class="col-md-6 col-lg-3">  <div class="card">   <div class="card-block user-radial-card">  <div data-label="50%" class="radial-bar radial-bar-100 radial-bar-lg radial-bar-Green">    <img src="' + link + '" alt="User-Image">     ' + '</div>   <span class="f-36 text-c-green   "> ' + x[i]['UserName'] + '</span>    <p> <a href="./UserProfile.aspx?userNo='+x[i]['profileId']+'" target="_blank"><i class="fa fa-linkedin-square">' + x[i]['UserName'] + ' </i></a> </p>   <p>  <i class="fa fa-audio-description">  ' + x[i]['Description'] + ' </i>  </p>');

                                }
                            },
                            error: function (err) {
                                alert(err);
                                console.log(err);
                            }
                        });
                        $(window).scroll(function () {
                            if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
                                alert(" loding More !");
                            
                                count = count + 150;
                                $.ajax({
                                    url: 'AllUsers.aspx/DataTableToJSONWithJSONNet',
                                    method: 'post',
                                    contentType: "application/json",
                                    data: '{count:' + count + '}',
                                    dataType: "json",

                                    success: function (data) {

                                        var x = data['d'];
                                        x = JSON.parse(x)
                                        //console.log();
                                        for (i = 0 ; i <= x.length; i++) {
                                            var link = "Images/NoImageFound.jpg";
                                            if (x[0]['ImageUrl'] != null)
                                                link = x[i]['ImageUrl'];

                                            if (link == "")
                                                link = "Images/NoImageFound.jpg";

                                            $("#items").append('<div class="col-md-6 col-lg-3">  <div class="card">   <div class="card-block user-radial-card">  <div data-label="50%" class="radial-bar radial-bar-100 radial-bar-lg radial-bar-Green">    <img src="' + link + '" alt="User-Image">     ' + '</div>   <span class="f-36 text-c-green   "> ' + x[i]['UserName'] + '</span>    <p> <a href="./UserProfile.aspx?userNo='+x[i]['profileId']+'" target="_blank"><i class="fa fa-linkedin-square">' + x[i]['UserName'] + ' </i></a> </p>   <p>  <i class="fa fa-audio-description">  ' + x[i]['Description'] + ' </i>  </p>');

                                        }
                                    },
                                    error: function (err) {
                                        alert(err);
                                        console.log(err);
                                    }
                                });
                            }
                        });



                    });

                });


           </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
