using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace trymodding.Content.Items.Weapons
{
    public class notBasicSword : ModItem
    {
        
        public override void SetDefaults()    //给物品设置基本属性
        {
            base.SetDefaults();
            //贴图宽度和高度
            Item.width = 40;
            Item.height = 40;

            //物品稀有度
            Item.rare = ItemRarityID.Blue;

            //最大堆叠数量（为什么武器要这个）
            Item.maxStack = 1;
            
            //物品价值，此为售卖价值
            Item.value =Item.sellPrice (0, 0, 0, 0);
            
            //设置物品是否可消耗
            Item.consumable = false;

            //设置武器伤害&伤害类型&暴击率，角色自带4%暴击率
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 20;     //游戏内显示20+4=24%

            // 这是控制贴图是否造成伤害，如果你是枪类的远程武器，你不希望拿着枪敲人的话就要把它设置为true
            Item.noMelee = false;

            // 这是控制使用时是否显示贴图，默认是有的，游戏内为true的例子是吸血飞刀
            Item.noUseGraphic = false;

            //设置物品使用时间，每秒使用次数=60/useTime
            Item.useTime = 20;
            Item.useAnimation = 20;

            //设置使用方式
            Item.useStyle = ItemUseStyleID.Swing;

            //设置击退值
            Item.knockBack = 10;
            
            //设置是否自动使用___鼠标爆破枪.gif
            Item.autoReuse = true;

            //设置使用音效
            Item.UseSound = SoundID.Item1;

            //设置使用时是否可以自动转身
            Item.useTurn = true;

            // 物品使用时发射的弹幕类型(这里是泰拉刃的剑气) & 物品发射弹幕的速度，单位：像素/帧，一秒 = 60帧
            Item.shoot = ProjectileID.TerraBeam;
            Item.shootSpeed = 6;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            base.MeleeEffects(player, hitbox);
            if (Main.GameUpdateCount % 3 == 0)
            {
                Dust d = Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height, DustID.Ichor);
                d.velocity *= 0;
                d.noGravity = true;
            }
        }
        public override void AddRecipes()   //给物品添加合成表
        {
            base.AddRecipes();
            //括号里的参数是生成物数量
            Recipe recipe = CreateRecipe(1);

            //给合成表添加材料
            recipe.AddIngredient(ItemID.Wood, 15);

            //设置合成环境&条件
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Condition.NearWater);

            //给合成表添加合成组
            recipe.AddRecipeGroup(RecipeGroupID.Wood,10);

            //注册合成表
            recipe.Register();
        }
    }
}
