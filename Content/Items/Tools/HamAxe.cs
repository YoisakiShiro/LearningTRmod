using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace trymodding.Content.Items.Tools
{
    public class HamAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;

            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 1;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.reuseDelay = 0;

            Item.useAnimation = 20;
            Item.useTime = 5;
            Item.UseSound = SoundID.Item1;

            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.hammer = 99;
            Item.axe = 30;

            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 6;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.IronBar,42);
            recipe.AddCondition(Condition.NearLava);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}