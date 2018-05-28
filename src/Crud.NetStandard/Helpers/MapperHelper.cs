﻿using System;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Crud.Model;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace Xlent.Lever.Libraries2.Crud.Helpers
{
    /// <summary>
    /// Help methods for mapping
    /// </summary>
    public static class MapperHelper
    {
        /// <summary>
        /// Map an id between two types.
        /// </summary>
        /// <param name="value">The id to map.</param>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <exception cref="FulcrumNotImplementedException">Thrown if the type was not recognized. Please add that type to the class <see cref="MapperHelper"/>.</exception>
        public static TTarget MapToType<TTarget, TSource>(TSource value)
        {
            if (value == null) return default(TTarget);
            if (Equals(value, default(TSource))) return default(TTarget);
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            if (targetType == typeof(string))
            {
                return (TTarget)(object)value.ToString();
            }
            if (targetType == typeof(Guid))
            {
                var success = Guid.TryParse(value.ToString(), out var valueAsGuid);
                InternalContract.Require(success, $"Could not parse parameter {nameof(value)} ({value}) of type {sourceType.Name} into type Guid.");
                return (TTarget)(object)valueAsGuid;
            }
            if (targetType == typeof(int))
            {
                var success = int.TryParse(value.ToString(), out var valueAsInt);
                InternalContract.Require(success, $"Could not parse parameter {nameof(value)} ({value}) of type {sourceType.Name} into type int.");
                return (TTarget)(object)valueAsInt;
            }
            if (targetType == typeof(int))
            {
                var success = int.TryParse(value.ToString(), out var valueAsInt);
                InternalContract.Require(success, $"Could not parse parameter {nameof(value)} ({value}) of type {sourceType.Name} into type int.");
                return (TTarget)(object)valueAsInt;
            }
            throw new FulcrumNotImplementedException($"There is currently no rule on how to convert an id from type {sourceType.Name} to type {targetType.Name}.");
        }
        /// <summary>
        /// Map an id between two types.
        /// </summary>
        /// <param name="value">The id to map.</param>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <typeparam name="TSource">The source type.</typeparam>
        /// <exception cref="FulcrumNotImplementedException">Thrown if the type was not recognized. Please add that type to the class <see cref="MapperHelper"/>.</exception>
        public static SlaveToMasterId<TTarget> MapToType<TTarget, TSource>(SlaveToMasterId<TSource> value)
        {
            if (value == null) return null;
            var targetMasterId = MapToType<TTarget, TSource>(value.MasterId);
            var targetSlaveId = MapToType<TTarget, TSource>(value.SlaveId);
            return new SlaveToMasterId<TTarget>(targetMasterId, targetSlaveId);
        }

    }
}