namespace Feliz.ReactFlow

open Fable.Core.JsInterop
open Fable.Core
open Feliz

type Event = Browser.Types.Event

[<Erase>]
type style =
    static member inline background(background: string) = Interop.mkAttr "background" background
    static member inline color(color: string) = Interop.mkAttr "color" color
    static member inline border(border: string) = Interop.mkAttr "border" border
    static member inline width(width: int) = Interop.mkAttr "width" width
    static member inline height(heigth: int) = Interop.mkAttr "heigth" heigth
    static member inline stroke(stroke: string) = Interop.mkAttr "stroke" stroke

[<Erase>]
type labelStyle =
    static member inline fill(fill: string) = Interop.mkAttr "fill" fill
    static member inline fontWeight(fontWeight: int) = Interop.mkAttr "fontWeight" fontWeight

// The !! below is used to "unsafely" expose a prop into an IReactFlowProp.
[<Erase>]
type ReactFlow =
    /// Creates a new ReactFlow component.
    static member inline flowChart(props: IReactFlowProp seq) =
        Interop.reactApi.createElement (Interop.reactFlow, createObj !!props)

    static member inline node (props: INodeProp seq): IElement =
        !!(createObj !!props)

    static member inline edge (props: IEdgeProp seq): IElement =
        !!(createObj !!props)

    /// Provides the child elements in a flow.
    static member inline elements(elements: IElement array) : IReactFlowProp = !!("elements" ==> elements)

    // Because the event helpers are inlined, Fable uncurrying is not working
    // so we make the conversion to delegate (Func) explicitly

    static member inline onElementClick(handler: Event -> Element -> unit) : IReactFlowProp =
        !!("onElementClick" ==> System.Func<_,_,_>handler)

    static member inline onElementsRemove(handler: Element[] -> unit) : IReactFlowProp =
        !!("onElementsRemove" ==> handler)

    static member inline onNodeDragStart(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDragStart" ==> System.Func<_,_,_>handler)

    static member inline onNodeDrag(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDrag" ==> System.Func<_,_,_>handler)

    static member inline onNodeDragStop(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeDragStop" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseEnter(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseEnter" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseMove(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseMove" ==> System.Func<_,_,_>handler)

    static member inline onNodeMouseLeave(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeMouseLeave" ==> System.Func<_,_,_>handler)

    static member inline onNodeContextMenu(handler: Event -> Node -> unit) : IReactFlowProp =
        !!("onNodeContextMenu" ==> System.Func<_,_,_>handler)

    static member inline onConnect(handler: {| source: Node; target: Node |} -> unit) : IReactFlowProp =
        !!("onConnect" ==> handler)

    static member inline onConnectStart(handler: Event -> {| nodeId: string; handleType: HandleType |} -> unit) : IReactFlowProp =
        !!("onConnectStart" ==> System.Func<_,_,_>handler)

    static member inline onConnectStop(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectStop" ==> handler)

    static member inline onConnectEnd(handler: Event -> unit) : IReactFlowProp =
        !!("onConnectEnd" ==> handler)

    // TODO: Rest of events: https://reactflow.dev/docs/api/component-props/