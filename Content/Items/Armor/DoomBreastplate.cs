using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TutorialMod.Content.Items.Armor
{

    [AutoloadEquip(EquipType.Body)]
    public class DoomBreastplate : ModItem
        {
            public static readonly int MaxHealthIncrease = 50;

            public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxHealthIncrease);

            public override void SetDefaults()
            {
                Item.width = 18; // Width of the item
                Item.height = 18; // Height of the item
                Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
                Item.rare = ItemRarityID.Green; // The rarity of the item
                Item.defense = 6; // The amount of defense the item will give when equipped
            }

            public override void UpdateEquip(Player player)
            {
                player.buffImmune[BuffID.OnFire] = true; // Make the player immune to Fire
                player.statLifeMax2 += MaxHealthIncrease; // Increase how many mana points the player can have by 20
            }

            // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
            public override void AddRecipes()
            {
                CreateRecipe()
                    .AddIngredient(ItemID.DirtBlock, 10)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
    }
}

