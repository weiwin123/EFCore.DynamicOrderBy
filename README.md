# EFCore.DynamicOrderBy

EFCore 多条件排序 例如：order by A,order by B,order by c desc；EFCore multi condition sorting, for example: order by A, order by B, order by c desc

# 使用方法

```
 var querys = ctx.TTest.DynamicOrderBy(
                new List<DynamicOrderByPredicate>()
                {
            new DynamicOrderByPredicate() {FieldName="SortIndex",IsDesc=true},
              new DynamicOrderByPredicate() {FieldName="CreateTime",IsDesc=true},
                }
                ).ToList();
```
