﻿//
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

public record ProgressModel : BaseAuditableEntity
{
    

    public string? ApplicationUserId { set; get; }
    public bool? Biodata { set; get; }
    public bool Results { set; get; }
    public bool Picture { set; get; }
    public bool Age { set; get; }
    public bool FormCompletion { set; get; }
    public bool Qualification { set; get; }
    public bool? DocumentUpload { set; get; }
    public bool? WorkingExperience { set; get; }
    public bool? AcademicExperience { set; get; }
    public bool? ResearchInformation { set; get; }
    public bool? ResearchPublication { set; get; }
    public bool? Referee { set; get; }
}
