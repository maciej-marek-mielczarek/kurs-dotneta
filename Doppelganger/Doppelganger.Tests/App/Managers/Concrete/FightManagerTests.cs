using System;
using System.Linq;
using System.Reflection;
using Doppelganger.App.Managers.Concrete;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Common;
using Xunit;

namespace Doppelganger.Tests.App.Managers.Concrete
{
    public class FightManagerTests
    {
        //Tests for method ValidNewOppNumbers
        
        //Tests for method Initialize
        
        //Tests for method CalculateScore
        
        //PickAllyMenu wants HelperMethods to be non-static, so that it can be mocked to supply given chars during test.
        
        //Same deal with PickOpp. It also wants to move away from FightSubMenu, preferably to a different class,
        //so that their connection can be cut and checked during test.
        
        //Same deal with FightSubMenu.
        
        //FightMenu is basically a View
    }
}