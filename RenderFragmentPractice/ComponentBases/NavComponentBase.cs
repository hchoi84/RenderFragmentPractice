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
    //builder.OpenElement(3, "li");
    //builder.OpenComponent<NavLink>(4);
    //builder.AddAttribute(5, "href", "/");
    //builder.AddAttribute(6, "Match", NavLinkMatch.All);
    //builder.AddAttribute(7, "ChildContent", (RenderFragment)((builder2) =>
    //{
    //  builder2.AddContent(8, "Home");
    //}));
    //builder.CloseComponent();
    //builder.CloseElement();

    BuildNavLinkItem(builder, false, "/contact", "Contact");
    //builder.OpenElement(9, "li");
    //builder.OpenComponent<NavLink>(10);
    //builder.AddAttribute(11, "href", "/contact");
    //builder.AddAttribute(12, "ChildContent", (RenderFragment)((builder2) =>
    //{
    //  builder2.AddContent(13, "Contact");
    //}
    //));
    //builder.CloseComponent();
    //builder.CloseElement();
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