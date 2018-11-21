<%@ Control Language="C#"
Inherits="System.Web.Mvc.ViewUserControl<Alloy_Demo_Site.Models.CriterionModels.GeographicCoordinateCriteria>" %>
<%@ Import Namespace="EPiServer.Personalization.VisitorGroups" %>


<div>
    <div class="epi-critera-block">
        <span class="epi-criteria-inlineblock">
            <%= Html.LabelFor(model => model.Range) %>
       
            <%= Html.DojoEditorFor(model => model.Range) %>
        </span>
        <span class="epi-criteria-inlineblock">
            <%= Html.LabelFor(model => model.Latitude) %>
        
            <%= Html.DojoEditorFor(model => model.Latitude) %>
        </span>
        <span class="epi-criteria-inlineblock">
            <%= Html.LabelFor(model => model.Longitude) %>
      
            <%= Html.DojoEditorFor(model => model.Longitude) %>
        </span>
        <span class="epi-criteria-inlineblock">
            <%= Html.LabelFor(model => model.Measurement) %>
      
            <%= Html.DojoEditorFor(model => model.Measurement) %>
        </span>
    </div>
</div>

