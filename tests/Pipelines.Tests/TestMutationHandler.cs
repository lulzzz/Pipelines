﻿using System;

namespace Pipelines.Tests
{
    public class TestMutationHandler : PipelineMutationDefinition<TestRequestA, TestRequestB, TestResponse>
    {
        public TestRequestA _request;
        public DateTime _timestamp;
        public override TestResponse Handle(TestRequestA request)
        {
            _request = request;
            _timestamp = DateTime.UtcNow;

            if (InnerHandler != null)
            {
                return InnerHandler.Handle(new TestRequestB());
            }

            return new TestResponse();
        }
    }
}
