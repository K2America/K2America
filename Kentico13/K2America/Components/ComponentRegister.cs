using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Widget Registration

[assembly: RegisterWidget("K2America.TextWithCTA", "Text With CTA Widget", typeof(TextWithCTAProperties), "~/Components/Widgets/TextWithCTA/_TextWithCTAView.cshtml", IconClass = "icon-badge")]
