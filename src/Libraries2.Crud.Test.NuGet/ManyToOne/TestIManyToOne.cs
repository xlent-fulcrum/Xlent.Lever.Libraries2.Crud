﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xlent.Lever.Libraries2.Crud.Interfaces;
using Xlent.Lever.Libraries2.Crud.Test.NuGet.Model;

namespace Xlent.Lever.Libraries2.Crud.Test.NuGet.ManyToOne
{
    /// <summary>
    /// Tests for testing any storage that implements <see cref="ICrud{TModelCreate,TModel,TId}"/>
    /// </summary>
    [TestClass]
    public abstract class TestIManyToOne<TId, TReferenceId> : TestIManyToOneBase<TId, TReferenceId> 
        
    { 
        /// <summary>
        /// Create a recursive relation
        /// </summary>
        [TestMethod]
        public async Task SimpleRelationAsync()
        {
            var parent = await CreateItemAsync(TypeOfTestDataEnum.Variant1);
            var child = await CreateItemAsync(CrudManyStorageNonRecursive, TypeOfTestDataEnum.Variant2, parent.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(child.ParentId);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(default(TReferenceId), child.ParentId);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(parent.Value, child.Value);
        }
    }
}

