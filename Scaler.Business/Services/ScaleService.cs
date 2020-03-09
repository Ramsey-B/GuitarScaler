using Scaler.Business.Interfaces;
using Scaler.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaler.Business.Services
{
    public class ScaleService
    {
        private readonly IScaleRepository _scaleRepository;
        private readonly INeckService _neckService;

        public ScaleService(IScaleRepository scaleRepository, INeckService neckService)
        {
            _scaleRepository = scaleRepository;
            _neckService = neckService;
        }
    }
}
