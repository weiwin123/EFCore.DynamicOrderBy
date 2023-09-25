# EFCore.DynamicOrderBy

本组件扩展了EFCore排序支持多条件排序 例如：order by A,order by B,order by c desc
<br>
This component extends the EFCore sorting support for multi condition sorting, such as: order by A, order by B, order by c desc

# 使用方法 Usage method

```
 var querys = ctx.TTest.DynamicOrderBy(
                new List<DynamicOrderByPredicate>()
                {
            new DynamicOrderByPredicate() {FieldName="SortIndex",IsDesc=true},
              new DynamicOrderByPredicate() {FieldName="CreateTime",IsDesc=true},
                }
                ).ToList();
```
