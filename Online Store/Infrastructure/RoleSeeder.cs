using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Online_Store.Infrastructure
{
    public static class RoleSeeder
    {

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {

            using var scope = serviceProvider.CreateScope();

            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = scope.ServiceProvider
                .GetRequiredService<UserManager<ApplicationUser>>();

            var configuration = scope.ServiceProvider
                .GetRequiredService<IConfiguration>();

            string[] roles = { "Admin", "Customer" };

            foreach (var role in roles)
            {

                if (!await roleManager.RoleExistsAsync(role))
                {
                    var result = await roleManager.CreateAsync(
                    new IdentityRole(role)
                    );

                    if (!result.Succeeded)
                    {
                        throw new Exception(
                            $"خطا در ایجاد نقش {role}: " +
                            string.Join(", ", result.Errors.Select(e => e.Description))
                        );
                    }

                }

            }


            // پیدا کردن ایمیل مدیر اولیه از تنظیمات
            var adminEmail = configuration["SeedAdmin:Email"];

            if (string.IsNullOrWhiteSpace(adminEmail))
            {
                throw new Exception("ایمیل مدیر اولیه در تنظیمات مشخص نشده است ");
            }

            // پیدا کردن کاربر با ایمیل مشخص شده
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if(adminUser == null)
            {
                throw new Exception("کاربر با ایمیل مدیر اولیه پیدا نشد !");
            }

            // بررسی اینکه آیا کاربر من از قبل مدیر هست یا نه 
            if(!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                var result = await userManager.AddToRoleAsync(adminUser , "Admin");

                if (!result.Succeeded)
                {
                    throw new Exception("خطا در اختصاص نقش مدیر به کاربر"
                        + string.Join(" , " , result.Errors.Select(e=>e.Description))
                        );
                }

            }


            // اختصاص نقش مشتری به کاربرانی در حال حاضر نقشی ندارند

            // دریافت همه کاربران ثبت نام شده 
            var users = await userManager.Users.ToListAsync();

            foreach(var user in users)
            {
                // اگر کاربر من مدیر بود ، ازش عبور کن
                if(await userManager.IsInRoleAsync(user , "Admin"))
                {
                    continue;
                }


                //اگر کاربر ما بدون نقش بود ، نقش مشتری را به او بده
                if (!await userManager.IsInRoleAsync(user , "Customer"))
                {

                    var result = await userManager.AddToRoleAsync(user , "Customer");

                    if (!result.Succeeded)
                    {
                        throw new Exception(
                            "خطا در اختصاص نقش مشتری" +
                            string.Join(" , " , result.Errors.Select(e => e.Description))
                            );
                    }

                }


            }


        }

    }
}
