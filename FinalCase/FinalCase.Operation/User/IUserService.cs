﻿using AutoMapper;
using FinalCase.Base;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Operation.Generic;
using FinalCase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Operation;

public interface IUSerService : IGenericService<User, UserRequest, UserResponse>
{ }