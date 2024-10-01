using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace PickUpClutter
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += DayStartedHandler;
            helper.Events.Player.InventoryChanged += InventoryChangedHandler;
        }

        private void InventoryChangedHandler(object? sender, InventoryChangedEventArgs e)
        {
            foreach (var i in e.Added)
            {
                if (i is StardewValley.Object o)
                {
                    o.GetContextTags().Add("placeable");
                }
            }
        }

        private void DayStartedHandler(object? sender, DayStartedEventArgs e)
        {
            foreach (var location in Game1.locations)
            {
                foreach (var o in location.objects.Values)
                {
                    o.IsSpawnedObject = true;
                }
            }
        }
    }
}
