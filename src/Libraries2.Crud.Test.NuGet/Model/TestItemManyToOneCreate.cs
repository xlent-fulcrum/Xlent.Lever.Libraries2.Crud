﻿using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace Xlent.Lever.Libraries2.Crud.Test.NuGet.Model
{
    /// <summary>
    /// A minimal storable item that implements <see cref="IUniquelyIdentifiable{TId}"/> to be used in testing
    /// </summary>
    public class TestItemManyToOneCreate<TReferenceId> : TestItemBare
    {
        public TReferenceId ParentId { get; set; }
    }
}
