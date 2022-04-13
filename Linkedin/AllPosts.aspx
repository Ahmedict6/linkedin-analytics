<%@ Page Title="linkedin |Archive  " Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AllPosts.aspx.cs" Inherits="CustomerPortal.AllPosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            table-layout: fixed;
            white-space: normal !important;
        }

        td {
            word-break: break-all;
        }



        .table {
            width: auto !important;
        }

        th, td {
            white-space: normal;
        }

        .td1 {
            width: 95% !important;
        }

        .td2 {
            width: 15% !important;
        }

        .td3 {
            width: 5% !important;
        }

        @media (max-width: 768px) { /* use the max to specify at each container level */
            .specifictd {
                width: 360px; /* adjust to desired wrapping */
                display: table;
                white-space: pre-wrap; /* css-3 */
                white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
                white-space: -pre-wrap; /* Opera 4-6 */
                white-space: -o-pre-wrap; /* Opera 7 */
                word-wrap: break-word; /* Internet Explorer 5.5+ */
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-6">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Archive
                                </h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="page-header-breadcrumb">
                           <%-- <asp:DropDownList ID="ddlGroups" runat="server" CssClass="form-control" OnSelectedIndexChanged="lblGroups_SelectedIndexChanged" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="GroupName" DataValueField="GroupId">
                            </asp:DropDownList>

                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrops" TypeName="InBLL.Data"></asp:ObjectDataSource>--%>

                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                <%-- <div class="row">


                    <div class="col-md-12" runat="server" id="DivNoData">
                        <div class="card table-card">
                            <div class="card-header">
                                <h3 class="sub-title text-c-lite-green">No Data Found</h3>
                            </div>

                            <div class="card-body text-center">
                                <h1 class="text-info">There is no data to show !</h1>
                            </div>
                        </div>
                    </div>

                </div>--%>
                <asp:DataList ID="dlGroupsPsot" DataKeyField="GroupId" Width="100%" runat="server" RepeatLayout="Flow" OnPreRender="dlPdfs_PreRender">

                    <ItemTemplate>
                        <div class="row">

                            <div class="col-md-12">
                                <div class="card table-card">
                                    <div class="card-header">
                                        <h3 class="sub-title text-c-lite-green">Group Name : <b><%# Eval("GroupName") %> </b></h3>
                                        <div class="card-header-right " style="margin-top: -18px;">
                                        </div>

                                    </div>

                                    <div class="card-block">
                                        <div class="table-responsive">


                                            <center>     
                                                    <div style="width:95%">
                                                <asp:GridView  ID="gvrData" CssClass="table  table-bordered table-hover"   AutoGenerateColumns="false"   runat="server"  >
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Post" ItemStyle-Width="80%"   DataField="GroupsPostText"  NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="User" ItemStyle-Width="15%" DataField="UserName"   NullDisplayText="--" />


                                                         <asp:TemplateField HeaderText="Account"   ItemStyle-Width="5%" >

                                                            <ItemTemplate>
                                                                <p><a href="<%#  "./UserProfile.aspx?userNo="+ Eval("profileId") %> " target="_blank"><i class="fa fa-linkedin-square"> view   </i></a></p>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     </Columns>
                                                    <HeaderStyle CssClass="text-amazon text-c-blue  border" />
                                                </asp:GridView>
                                        </div>
                                                </center>




                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

                <div class="row">


                    <asp:Repeater ID="dlUsersPostingReport" runat="server">
                        <ItemTemplate>
                            <div class="col-md-6 col-lg-3">
                                <div class="card">
                                    <div class="card-block user-radial-card">
                                        <span class="f-28 text-c-green"><%# Eval("GroupName") %></span>
                                        <div data-label="50%" class="radial-bar radial-bar-100 radial-bar-lg radial-bar-primary">
                                            <img src="<%# ( Eval("ImageUrl").ToString() =="") ? "Images/NoImageFound.jpg" : Eval("ImageUrl")  %>" alt="User-Image">
                                        </div>
                                        <span class="f-36 text-c-green   "><%# Eval("PostsCounter") %></span>
                                        <p><a href="<%#  "./UserProfile.aspx?userNo="+ Eval("profileId") %> " target="_blank"><i class="fa fa-linkedin-square"><%# Eval("UserName") %> </i></a></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                    </asp:Repeater>




                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
