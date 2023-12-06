//
//  Copyright 2021  2021
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using System.ComponentModel.DataAnnotations;
namespace ApplicantPortal.Domain.Entities;
public record SaleModel
{
    [Key]
    public int Id { set; get; }
    public string? Pin { set; get; }
    public string? Serial { get; init; }
    public string? Belongs { set; get; }
    public string? Type { set; get; }
    public string? CustomerName { set; get; }
    public string? CustomerPhone { set; get; }
    [DataType(DataType.Date)]
    public DateTime DateSold => DateTime.UtcNow;
    public string? Year { set; get; }
    public int Free { set; get; }
    public int Deleted { set; get; }
    public decimal Price { set; get; }
    public int SoldBy { set; get; }
    
}
