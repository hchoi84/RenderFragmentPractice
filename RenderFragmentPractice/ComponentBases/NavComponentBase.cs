using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Routing;

namespace RenderFragmentPractice.ComponentBases;

public class NavComponentBase : ComponentBase
{
  private int _index = 0;

  protected override void BuildRenderTree(RenderTreeBuilder builder)
  {
    builder.OpenElement(_index++, "nav");
    builder.AddAttribute(_index++, "class", "menu");

    builder.OpenElement(_index++, "ul");
    BuildNavLinkItem(builder, true, "/", "Home");
    BuildNavLinkItem(builder, false, "/contact", "Contact");
    builder.CloseElement();

    builder.CloseElement();
  }

  private void BuildNavLinkItem(RenderTreeBuilder builder, bool matchAll, string link, string displayName)
  {
    builder.OpenElement(_index++, "li");
    builder.OpenComponent<NavLink>(_index++);
    builder.AddAttribute(_index++, "href", link);
    if (matchAll)
    {
      builder.AddAttribute(_index++, "Match", NavLinkMatch.All);
    }

    builder.AddAttribute(_index++, "ChildContent", (RenderFragment)((builder2) =>
    {
      builder2.AddContent(_index++, displayName);
    }
    ));
    builder.CloseComponent();
    builder.CloseElement();
  }
}