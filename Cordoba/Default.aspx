<%@ Page Title="Cordoba" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cordoba._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>a city in Andalusia, southern Spain, and the capital of the province of Córdoba. An Iberian and Roman city in ancient times, in the Middle Ages it became the capital of an Islamic caliphate.
</h2>
            </hgroup>
            <p>
               
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Skapa ärende</h3>
    Titel: <asp:TextBox ID="Heading" runat="server"></asp:TextBox><br/>
    Beskrivning: <asp:TextBox ID="Description" runat="server"></asp:TextBox><br/>
    Kund: <asp:TextBox ID="CustomerName" runat="server" /><br />
    Tjänst: <asp:TextBox ID="CustomerService" runat="server" /><br />
    Status: <asp:DropDownList ID="Status" runat="server"/><br />
    <asp:Button ID="Submit" runat="server" Text="Skapa" OnClick="Submit_Click"/>
    <asp:Label ID="CreateResult" runat="server"/>

    <h3>Pågående ärenden</h3>
    <asp:GridView ID="OngoingGrid" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Title" HeaderText="Titel" />
            <asp:BoundField DataField="Description" HeaderText="Beskrivning" />
            <asp:BoundField DataField="Duration.StartTime" HeaderText="Starttid" />
            <asp:BoundField DataField="Duration.EndTime" HeaderText="Sluttid" />
            <asp:BoundField DataField="AffectedCustomers.Count" HeaderText="Antal kunder" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
        </Columns>
    </asp:GridView>
</asp:Content>
