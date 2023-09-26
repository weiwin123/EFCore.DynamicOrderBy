# EFCore.DynamicOrderBy

本组件扩展了EFCore排序 1.支持直接使用数据表字段排序 2.支持多条件排序
<br>
This component extends EFCore sorting 1. Supports direct use of data table field sorting 2. Supports multi condition sorting

# 使用方法 Usage method

```
 var orderByPredicates = new List<DynamicOrderByPredicate>();
            if (!string.IsNullOrEmpty(SortIndex))
            {
                orderByPredicates.Add(new DynamicOrderByPredicate() { FieldName = "SortIndex", IsDesc = true });
            }
            if (!string.IsNullOrEmpty(CreateTime))
            {
                orderByPredicates.Add(new DynamicOrderByPredicate() { FieldName = "CreateTime", IsDesc = false });
            }
            var querys = ctx.TTest.DynamicOrderBy(
           orderByPredicates
            ).ToList();
```
