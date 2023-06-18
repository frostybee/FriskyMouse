﻿using FriskyMouse.Settings;
using FriskyMouse.UI;

namespace FriskyMouse.Core
{
    //TODO: Dispose everything here.
    internal class DecorationController : IDisposable
    {
        private static readonly Lazy<DecorationController> _instance =
            new Lazy<DecorationController>(() => new DecorationController());        
        private readonly ApplicationSettings _settings;        
        private readonly HighlighterController _highlighter;
        private readonly RippleProfilesAnimator _leftClickDecorator;
        private readonly RippleProfilesAnimator _rightClickDecorator;
        private readonly MouseHookController _mouseHookController;
        private readonly object _syncLock = new object();
        private bool _disposed = false;

        private DecorationController()
        {
            _settings = SettingsManager.Settings;
            _leftClickDecorator = new RippleProfilesAnimator(_settings.LeftClickOptions);
            _rightClickDecorator = new RippleProfilesAnimator(_settings.RightClickOptions);
            _highlighter = new HighlighterController(_settings);
            _mouseHookController = new MouseHookController(_highlighter, _leftClickDecorator, _rightClickDecorator);
        }

        #region Methods
        
        internal void EnableHighlighter()
        {            
            _highlighter.InitHighlighter(_settings.HighlighterOptions);        
        }         
        internal void DisableHighlighter()
        {
            // HideSpotlight the layered window.
            _highlighter.HideSpotlight();
            if (_settings.HighlighterOptions.Enabled)
            {

            }
        }
        public void EnableHook()
        {
            lock (_syncLock)
            {
                _mouseHookController?.Install();
            }
        }
        public void DisableHook()
        {
            lock (_syncLock)
            {
                //TODO: dispose bitmaps
                _mouseHookController?.Uninstall();
                // HideSpotlight the layered window.
                _highlighter?.HideSpotlight();
            }
        }

        internal void ApplyHighlighterSettings()
        {
            // Save the newly edited settings.
            SettingsManager.SaveSettings();

            if (_settings.HighlighterOptions.Enabled)
            {                
                EnableHighlighter();
            }
        }

        internal void BootstrapApp()
        {
            // TODO: add check ==> Is click decorator enabled as well?
            EnableHook();
            if (_mouseHookController.Started)
            {
                if (_settings.HighlighterOptions.Enabled)
                {
                    // Set the initial coordinates of the spotlight upon starting the application.
                    _highlighter.SetInitialPosition();
                    EnableHighlighter();
                }
            }
            else 
            {
                // TODO: Failed to install the mouse hook... Raise an error.
            }                    
        }        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {                    
                    _highlighter?.Dispose();                    
                    _leftClickDecorator?.Dispose();
                    _rightClickDecorator?.Dispose();    
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }        

        #endregion

        #region Properties
        /// <summary>
        /// Gets the single instance of the decoration engine.
        /// </summary>
        public static DecorationController Instance => _instance.Value;        
        public HighlighterController MouseHighlighter => _highlighter;
        public RippleProfilesAnimator ClickDecorator => _leftClickDecorator;

        public MainForm MainForm { get; internal set; }

        #endregion
    }
}