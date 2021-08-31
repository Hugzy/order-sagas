using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebusTest.EFCore;
using RebusTest.EFCore.Models.DbModels;

namespace RebusTest
{
    public class EfCoreFuckery
    {
        public async Task Main()
        {
            var test = new Test();
            // await Create();
            // await Update(new Test {Id = 3});
            // await AddFoo(test);
            // test.Id = 4;
            // await GetFoo(test);
            await Update();
        }

        #region Foo/Test

        

        public async Task Create()
        {
            await using var context = new TestContext();
            var test = new Test
            {
                Text = "test",
                Foo = new Foo()
                {
                    Text = "foo"
                }
            };

            context.Tests.Add(test);
            await context.SaveChangesAsync();
        }

        public async Task Update(Test test)
        {
            await using var context = new TestContext();

            var model = await context.Tests.FirstOrDefaultAsync(t => t.Id == test.Id);
            model.Text += "copy";
            context.Tests.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task AddFoo(Test test)
        {
            await using var context = new TestContext();
            
            var foo = new Foo()
            {
                Text = "foo",
            };

            var entity = await context.Tests.FindById(test);

            entity.Foo = foo;

            await context.SaveChangesAsync();
        }

        public async Task GetFoo(Test test)
        {
            await using var context = new TestContext();

            var entity = await context.Tests.Include(t => t.Foo).FindById(test);

            Console.WriteLine(entity);
        }
        
        
        #endregion

        public async Task Update()
        {
            await using var context = new TestContext();
            context.PrincipalEntities.Add(new PrincipalEntity()
            {
                Text = "test",
            });
            await context.SaveChangesAsync();

            var p1 = await context.PrincipalEntities.FirstAsync();
            p1.DependantEntities = new DependantEntity()
            {
                Text = "Test dependant"
            };

            context.SaveChanges();

            var p2 = await context.PrincipalEntities.FirstAsync();
            Debug.Assert(p2.DependantEntities.Text == "Test dependant");

            p2.DependantEntities = new DependantEntity()
            {
                Text = "Test dependant 2"
            };

            context.SaveChanges();

            var p3 = await context.PrincipalEntities.FirstAsync();
            Debug.Assert(p3.Text == "Test dependant 2");
        }
    }
} 