    // DTO هو كائن وظيفته نقل البيانات بأمان وسرعة بين السيرفر 
    //مع إخفاء تفاصيل قاعدة البيانات الحساسة وعرض المطلوب فقط
    // من العميل للسيرفر أو العكس
 namespace GameStore.Api.Dtos;
public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
      