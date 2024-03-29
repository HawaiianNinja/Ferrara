﻿// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=392286
(function () {
    "use strict";

   

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    var canvas;
    var context;

    //apparently this is a CreateJS/EaselJS thing
    var gameStage;

    //apparently this is a PreloadJS thing
    var preloadQueue;


    //images
    var redDotImage;
    var redDotBitmap;




    function initialize() {

        canvas = document.getElementById("gameCanvas");

        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        context = canvas.getContext("2d");
        
        gameStage = new createjs.Stage(canvas);

        loadContent();

    }

    function loadContent() {

        preloadQueue = new createjs.LoadQueue();
        
        preloadQueue.on("complete", prepareStage, this); //no idea what "this" refers to yet



        var manifest = [

            { id: "redDot", src: "images/GFX/RedDot.png" },
            { id: "blueDot", src: "images/GFX/BlueDot.png" }

        ];

        preloadQueue.loadManifest(manifest);

    }

    function prepareStage() {

        redDotImage = preloadQueue.getResult("redDot");

        redDotBitmap = new createjs.Bitmap(redDotImage);


        gameStage.addChild(redDotBitmap);


        createjs.Ticker.setInterval(window.requestAnimationFrame);

        // this seems to be old and doesn't work anymore
        //createjs.Ticker.addListener(gameLoop);

        createjs.Ticker.addEventListener("tick", gameLoop);


    }


    function gameLoop() {

        update();
        console.log("tick");
        draw();

    }

    function update() {

    }

    function draw() {
        gameStage.update();
    }







    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll());
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    document.addEventListener("DOMContentLoaded", initialize, false);

    app.start();
})();