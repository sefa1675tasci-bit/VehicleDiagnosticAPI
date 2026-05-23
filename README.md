# VehicleDiagnosticAPI

Bu proje ASP.NET Core Web API kullanılarak geliştirilmiş bir araç teşhis sistemidir.

## Özellikler

- Motor sıcaklığı analizi
- Yağ basıncı kontrolü
- Soğutma sıvısı kontrolü
- Warning / Critical durum analizi
- Fan kontrol sistemi
- Emergency mode sistemi
- Araç geçmiş kayıtları
- Genel sistem sağlık kontrolü

## Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger UI

## API Endpointleri

### Araç Analizi
POST /api/Vehicle/analyze

### Geçmiş Kayıtlar
GET /api/Vehicle/history

### Sistem Sağlığı
GET /api/Vehicle/health
